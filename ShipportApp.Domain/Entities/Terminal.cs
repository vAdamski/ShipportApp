using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Domain.Entities
{
    public class Terminal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? ATB { get; set; }
        public DateTime? ATD { get; set; }
    }
}
