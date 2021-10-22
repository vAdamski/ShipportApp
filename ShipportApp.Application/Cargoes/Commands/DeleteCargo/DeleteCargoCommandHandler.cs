using MediatR;
using ShipportApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Commands.DeleteCargo
{
    public class DeleteCargoCommandHandler : IRequestHandler<DeleteCargoCommand>
    {
        private IAppDatabase _appDatabase;

        public DeleteCargoCommandHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<Unit> Handle(DeleteCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = _appDatabase.cargos.Where(x => x.Id == request.CargoId).FirstOrDefault();

            _appDatabase.cargos.Remove(cargo);

            return Unit.Value;
        }
    }
}
