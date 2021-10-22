using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Terminals.Queries.GetTerminal
{
    public class GetTerminalQuery : IRequest<TerminalVm>
    {
        public string TerminalId { get; set; }
    }
}
