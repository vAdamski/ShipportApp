using ShipportApp.Application.Cargoes.Queries.GetCargoes;
using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Rotations.Queries.GetRotation
{
    public class TerminalDto
    {
        public string Name { get; set; }
        public List<Cargo> Cargoes { get; set; }
    }
}
