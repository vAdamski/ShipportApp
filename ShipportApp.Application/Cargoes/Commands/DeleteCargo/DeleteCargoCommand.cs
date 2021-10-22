using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.DeleteCargo
{
    public class DeleteCargoCommand : IRequest
    {
        public string CargoId { get; set; }
    }
}
