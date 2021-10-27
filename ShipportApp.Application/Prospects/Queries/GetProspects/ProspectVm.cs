using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Prospects.Queries.GetProspects
{
    public class ProspectVm
    {
        public DateTime ATA { get; set; }
        public List<ProspectTerminalDto> prospectDtos { get; set; }
    }
}
