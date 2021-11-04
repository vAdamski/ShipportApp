using MediatR;
using ShipportApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Prospects.QueriesV2.GetProspects
{
    public class GetProspectQueryHandler : IRequestHandler<GetProspectQuery, ProspectVm>
    {
        private IAppDatabase _appDatabase;

        public GetProspectQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<ProspectVm> Handle(GetProspectQuery request, CancellationToken cancellationToken)
        {
            var cargoes = _appDatabase.cargos;
            var terminals = _appDatabase.terminals;

            var prospectVm = new ProspectVm();
            prospectVm.prospectDtos = new List<ProspectDto>();

            var listOfProspectDtos = prospectVm.prospectDtos;



            terminals.ForEach(terminal =>
            {
                var cargoesInTerminal = cargoes.Where(cargo => cargo.TerminalId == terminal.Id).ToList();
                var countCargoesInTerminal = cargoesInTerminal.Count();

                if (countCargoesInTerminal > 0)
                {
                    listOfProspectDtos.Add(new ProspectDto { ActionName = "ATB", Description = terminal.Name, Date = cargoesInTerminal.First().ATC.Value.AddDays(-1) });
                    cargoesInTerminal.ForEach(cargo =>
                    {
                        listOfProspectDtos.Add(new ProspectDto { ActionName = "ATC", Description = cargo.Name, Date = cargo.ATC });
                    });
                    listOfProspectDtos.Add(new ProspectDto { ActionName = "ATD", Description = terminal.Name, Date = cargoesInTerminal.Last().ATC.Value.AddDays(1) });
                }
            });

            var firstItem = listOfProspectDtos.First();

            listOfProspectDtos.Insert(0, new ProspectDto { ActionName = "ATA", Date = firstItem.Date.Value.AddDays(-1) });
            listOfProspectDtos.Add(new ProspectDto { ActionName = "ATD", Date = listOfProspectDtos.Last().Date.Value.AddDays(1) });

            return prospectVm;
        }
    }
}
