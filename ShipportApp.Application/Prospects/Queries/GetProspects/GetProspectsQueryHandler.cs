using MediatR;
using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Prospects.Queries.GetProspects
{
    public class GetProspectsQueryHandler : IRequestHandler<GetProspectsQuery, ProspectVm>
    {
        private IAppDatabase _appDatabase;

        public GetProspectsQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<ProspectVm> Handle(GetProspectsQuery request, CancellationToken cancellationToken)
        {
            var terminals = _appDatabase.terminals;
            var cargoes = _appDatabase.cargos;

            var prospectVm = new ProspectVm();
            prospectVm.prospectDtos = new List<ProspectTerminalDto>();

            terminals.ForEach(terminal =>
            {
                var cargoesInTerminal = cargoes.Where(cargo => cargo.TerminalId == terminal.Id);
                var countCargoesInTerminal = cargoesInTerminal.Count();
                if (countCargoesInTerminal > 0)
                {
                    prospectVm.prospectDtos.Add(
                        new ProspectTerminalDto
                        {
                            Name = terminal.Name,
                            ATB = cargoesInTerminal.OrderBy(cargo => cargo.ATC).FirstOrDefault().ATC.Value.AddDays(-1),
                            ATD = cargoesInTerminal.OrderByDescending(cargo => cargo.ATC).FirstOrDefault().ATC.Value.AddDays(1),
                            Cargoes = cargoesInTerminal.ToList()
                        });
                }
            });

            prospectVm.prospectDtos.Sort((a, b) => a.ATD.Value.CompareTo(b.ATD.Value));

            prospectVm.prospectDtos.ForEach(x =>
            {
                x.Cargoes.Sort((a, b) => a.ATC.Value.CompareTo(b.ATC.Value));
            });

            prospectVm.ATA = prospectVm.prospectDtos.FirstOrDefault().ATB.Value.AddDays(-1);

            return prospectVm;
        }
    }
}
