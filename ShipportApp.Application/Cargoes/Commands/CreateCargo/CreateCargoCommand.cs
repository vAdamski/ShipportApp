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
        private string _id;

        public string Id 
        {
            get
            {
                if(this._id == null)
                {
                    this._id = Guid.NewGuid().ToString();
                }
                return _id;
            }
            set
            {
                //this._id = Guid.NewGuid().ToString();
            }
        }
        public string Name { get; set; }
        public string TerminalId { get; set; }
        public DateTime? ATC { get; set; }
    }
}
