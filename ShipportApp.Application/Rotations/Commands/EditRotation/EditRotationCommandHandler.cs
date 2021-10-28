using MediatR;
using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Application.Rotations.Queries.GetRotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipportApp.Application.Rotations.Commands.EditRotation
{
    public class EditRotationCommandHandler : IRequestHandler<EditRotationCommand, EditRotationVm>
    {
        private IAppDatabase _appDatabase;

        public EditRotationCommandHandler(IAppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        public async Task<EditRotationVm> Handle(EditRotationCommand request, CancellationToken cancellationToken)
        {
            var cargoesDb = _appDatabase.cargos;
            var terminalsDb = _appDatabase.terminals;

            var rotationDtos = request.EditRotationVm.rotationDtos;

            cargoesDb.ForEach(x =>
            {
                x.TerminalId = "";
                x.ATC = DateTime.MinValue;
            });

            rotationDtos.ForEach(terminal =>
            {
                foreach (var cargo in terminal.Cargoes)
                {
                    var cargoToUpdate = cargoesDb.FirstOrDefault(x => x.Id == cargo.Id);

                    var terminalIdExist = terminalsDb.Where(y => y.Id == terminal.TerminalId).FirstOrDefault();

                    if ((terminalIdExist != null || string.IsNullOrWhiteSpace(terminal.TerminalId)) && cargoToUpdate != null)
                    {
                        cargoToUpdate.TerminalId = terminalIdExist.Id;
                        cargoToUpdate.ATC = terminal.Cargoes.Where(x => x.Id == cargo.Id).FirstOrDefault().ATC;
                    }
                }
            });

            return request.EditRotationVm;
        }
    }
}

