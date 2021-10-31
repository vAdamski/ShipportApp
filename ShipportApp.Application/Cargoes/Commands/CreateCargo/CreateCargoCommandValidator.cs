using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.CreateCargo
{
    public class CreateCargoCommandValidator : AbstractValidator<CreateCargoCommand>
    {
        public CreateCargoCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.ATC).NotEmpty();
        }
    }
}
