using ShipportApp.Application.Cargoes.Queries.GetCargoes;
using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Terminals.Queries.GetTerminals
{
    public class TerminalDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Cargo> cargoes { get; set; }
        public DateTime? ATB { get; set; }
        public DateTime? ATD { get; set; }
    }
}
