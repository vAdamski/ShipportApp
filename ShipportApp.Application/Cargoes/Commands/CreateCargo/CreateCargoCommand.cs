using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.CreateCargo
{
    public class CreateCargoCommand : IRequest<string>
    {
        public string Id 
        {
            get
            {
                return Id;
            }
            set
            {
                Id = Guid.NewGuid().ToString();
            }
        }
        public string Name { get; set; }
        [Required]
        public string TerminalId { get; set; }
        public DateTime? ATC { get; set; }
    }
}
