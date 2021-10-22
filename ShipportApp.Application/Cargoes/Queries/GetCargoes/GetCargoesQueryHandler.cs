using MediatR;
using ShipportApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Cargoes.Queries.GetCargoes
{
    public class GetCargoesQueryHandler : IRequestHandler<GetCargoesQuery, CargoesVm>
    {
        private IAppDatabase _appDatabase;

        public GetCargoesQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<CargoesVm> Handle(GetCargoesQuery request, CancellationToken cancellationToken)
        {
            var cargoes = _appDatabase.cargos;

            if (cargoes == null)
            {
                return null;
            }

            var cargoesVm = new CargoesVm();

            cargoesVm.cargoes = new List<CargoDto>();

            cargoes.ForEach(cargo => cargoesVm.cargoes.Add(new CargoDto { Id = cargo.Id, Name = cargo.Name, TerminalId = cargo.TerminalId, ATC = cargo.ATC }));

            if(cargoesVm.cargoes == null)
            {
                return null;
            }

            return cargoesVm;
        }
    }
}
