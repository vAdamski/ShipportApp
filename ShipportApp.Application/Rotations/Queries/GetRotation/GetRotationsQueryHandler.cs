using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShipportApp.Application.Common.Interfaces;

namespace ShipportApp.Application.Rotations.Queries.GetRotation
{
    public class GetRotationsQueryHandler : IRequestHandler<GetRotationsQuery, RotationVm>
    {
        private readonly IAppDatabase _appDatabase;

        public GetRotationsQueryHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }
        public async Task<RotationVm> Handle(GetRotationsQuery request, CancellationToken cancellationToken)
        {
            var terminals = _appDatabase.terminals;
            var cargoes = _appDatabase.cargos;

            var rotationVm = new RotationVm();
            rotationVm.terminals = new List<RotationDto>();

            terminals.ForEach(terminal =>
            {
                var cargoesInTerminal = cargoes.Where(cargo => cargo.TerminalId == terminal.Id);
                var countCargoesInTerminal = cargoesInTerminal.Count();
                if (countCargoesInTerminal > 0)
                {
                    rotationVm.terminals.Add(
                        new RotationDto
                        {
                            Name = terminal.Name,
                            Cargoes = cargoesInTerminal.ToList()
                        });
                }
            });

            return rotationVm;
        }
    }
}

