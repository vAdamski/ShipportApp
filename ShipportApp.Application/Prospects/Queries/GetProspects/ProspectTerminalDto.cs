using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Prospects.Queries.GetProspects
{
    public class ProspectTerminalDto
    {
        public string Name { get; set; }
        public DateTime? ATB { get; set; }
        public DateTime? ATD { get; set; }
        public List<Cargo> Cargoes { get; set; }
    }
}
