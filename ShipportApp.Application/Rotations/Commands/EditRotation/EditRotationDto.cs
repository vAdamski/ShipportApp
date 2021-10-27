using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Rotations.Commands
{
    public class EditRotationDto
    {
        public string TerminalId { get; set; }
        public List<Cargo> Cargoes { get; set; }
    }
}
