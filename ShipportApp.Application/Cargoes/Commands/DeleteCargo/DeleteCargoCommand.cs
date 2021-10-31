using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.DeleteCargo
{
    public class DeleteCargoCommand : IRequest
    {
        [Required]
        public string CargoId { get; set; }
    }
}
