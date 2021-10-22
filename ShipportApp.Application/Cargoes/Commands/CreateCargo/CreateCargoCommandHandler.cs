using MediatR;
using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.CreateCargo
{
    public class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, string>
    {
        private IAppDatabase _appDatabase;

        public CreateCargoCommandHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<string> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cargo cargo = new Cargo()
                {
                    Name = request.Name,
                    Id = request.Id,
                    ATC = request.ATC,
                    TerminalId = request.TerminalId
                };

                _appDatabase.cargos.Add(cargo);

                return cargo.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
