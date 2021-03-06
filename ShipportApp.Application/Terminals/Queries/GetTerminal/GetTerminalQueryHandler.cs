using MediatR;
using Microsoft.EntityFrameworkCore;
using ShipportApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Terminals.Queries.GetTerminal
{
    public class GetTerminalQueryHandler : IRequestHandler<GetTerminalQuery, TerminalVm>
    {
        private readonly IAppDatabase _appDatabase;

        public GetTerminalQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }
        public async Task<TerminalVm> Handle(GetTerminalQuery request, CancellationToken cancellationToken)
        {
            //Use Validation for this...
            if(string.IsNullOrWhiteSpace(request.TerminalId))
            {
                return null;
            }

            var terminal = _appDatabase.terminals.Where(x => x.Id == request.TerminalId).FirstOrDefault();

            if(terminal == null)
            {
                return null;
            }

            var terminalVm = new TerminalVm
            {
                Id = request.TerminalId,
                Name = terminal.Name,
                ATB = terminal.ATB,
                ATD = terminal.ATD
            };

            return terminalVm;
        }
    }
}
