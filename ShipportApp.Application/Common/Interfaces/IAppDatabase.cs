using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Common.Interfaces
{
    public interface IAppDatabase
    {
        List<Cargo> cargos { get; set; }
        List<Terminal> terminals { get; set; }
    }
}
