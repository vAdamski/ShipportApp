using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Rotations.Commands.EditRotation
{
    public class EditRotationCommand : IRequest<EditRotationVm>
    {
        public EditRotationVm EditRotationVm { get; set; }
    }
}
