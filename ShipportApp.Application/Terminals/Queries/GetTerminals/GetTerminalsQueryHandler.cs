using MediatR;
using ShipportApp.Application.Cargoes.Queries.GetCargoes;
using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Application.Terminals.Queries.GetTerminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Terminals.Queries.GetTerminals
{
    public class GetTerminalsQueryHandler : IRequestHandler<GetTerminalsQuery, TerminalsVm>
    {
        private readonly IAppDatabase _appDatabase;

        public GetTerminalsQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }
        public async Task<TerminalsVm> Handle(GetTerminalsQuery request, CancellationToken cancellationToken)
        {
            var terminals = _appDatabase.terminals;

            var cargoes = _appDatabase.cargos;

            var terminalsVm = new TerminalsVm();

            terminalsVm.terminals = new List<TerminalDto>();

            terminals.ForEach(terminal => terminalsVm.terminals.Add(
                new TerminalDto
                {
                    Id = terminal.Id,
                    Name = terminal.Name,
                    ATB = terminal.ATB,
                    ATD = terminal.ATD,
                    Cargoes = cargoes.Where(x => x.TerminalId == terminal.Id).ToList()
                }));

            return terminalsVm;
        }
    }
}
