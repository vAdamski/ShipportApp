using Application.UnitTest.Common;
using ShipportApp.Application.Cargoes.Commands.CreateCargo;
using ShipportApp.Application.Cargoes.Commands.DeleteCargo;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.UnitTests.NewFolder.Cargoes.Commands
{
    public class DeleteCargoCommandHandlerTest : CommandTestBase
    {
        private readonly DeleteCargoCommandHandler _handlerDelete;
        private readonly CreateCargoCommandHandler _handlerCreate;

        public DeleteCargoCommandHandlerTest() : base()
        {
            _handlerDelete = new DeleteCargoCommandHandler(_appDatabase);
            _handlerCreate = new CreateCargoCommandHandler(_appDatabase);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteCargo()
        {
            var commandCreate = new CreateCargoCommand()
            {
                Name = "Test",
                TerminalId = "",
                ATC = DateTime.Now
            };

            var resault = await _handlerCreate.Handle(commandCreate, CancellationToken.None);

            var commandDelete = new DeleteCargoCommand
            {
                CargoId = resault
            };

            _handlerDelete.Handle(commandDelete, CancellationToken.None);

            var dir = _appDatabase.cargos.FirstOrDefault(x => x.Id == resault);

            dir.ShouldBeNull();
        }
    }
}
