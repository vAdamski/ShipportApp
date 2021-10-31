using Application.UnitTest.Common;
using ShipportApp.Application.Cargoes.Queries.GetCargoes;
using ShipportApp.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.UnitTests.NewFolder.Cargoes.Queries
{
    public class GetCargoesQueryHandlerTest : CommandTestBase
    {
        private readonly GetCargoesQueryHandler _handler;

        public GetCargoesQueryHandlerTest() : base()
        {
            _handler = new GetCargoesQueryHandler(_appDatabase);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllCargoes()
        {
            var querry = new GetCargoesQuery();

            var resault = await _handler.Handle(querry, CancellationToken.None);

            //Use mapper for this...
            var reasultCargo = new List<Cargo>();
            foreach (var cargo in resault.cargoes)
            {
                reasultCargo.Add(
                    new Cargo
                    {
                        Id = cargo.Id,
                        Name = cargo.Name,
                        ATC = cargo.ATC,
                        TerminalId = cargo.TerminalId
                    });
            }

            var dir = _appDatabase.cargos;

            dir.ShouldBe(reasultCargo);
        }
    }
}
