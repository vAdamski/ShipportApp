using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Terminals.Queries.GetTerminals
{
    public class TerminalsVm
    {
        public List<TerminalDto> terminals { get; set; }
    }
}
