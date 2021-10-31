using Application.UnitTest.Common;
using ShipportApp.Application.Cargoes.Commands.CreateCargo;
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
    public class CreateCargoCommandHandlerTest : CommandTestBase
    {
        private readonly CreateCargoCommandHandler _handler;

        public CreateCargoCommandHandlerTest() : base()
        {
            _handler = new CreateCargoCommandHandler(_appDatabase);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertCargo()
        {
            var command = new CreateCargoCommand()
            {
                Name = "Test",
                ATC = DateTime.Now
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var dir = _appDatabase.cargos.FirstOrDefault(x => x.Id == result);

            dir.ShouldNotBeNull();
        }

        [Fact]
        public async Task Handle_GivenNotValidRequest_ShouldReturnNull()
        {
            var command = new CreateCargoCommand()
            {
                Name = "",
                ATC = DateTime.Now
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var dir = _appDatabase.cargos.FirstOrDefault(x => x.Id == result);

            dir.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_GivenNotValidRequestDataTimeNull_ShouldReturnNull()
        {
            var command = new CreateCargoCommand()
            {
                Name = "Keyboard",
                ATC = null
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var dir = _appDatabase.cargos.FirstOrDefault(x => x.Id == result);

            dir.ShouldBeNull();
        }
    }
}
