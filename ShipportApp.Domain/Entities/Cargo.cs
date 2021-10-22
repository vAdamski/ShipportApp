using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Domain.Entities
{
    public class Cargo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TerminalId { get; set; }
        public DateTime? ATC { get; set; }
    }

}
