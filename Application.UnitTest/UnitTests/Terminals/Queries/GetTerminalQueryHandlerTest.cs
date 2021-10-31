using Application.UnitTest.Common;
using ShipportApp.Application.Terminals.Queries.GetTerminal;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.UnitTests.Terminals.Queries
{
    public class GetTerminalQueryHandlerTest : CommandTestBase
    {
        private readonly GetTerminalQueryHandler _handler;

        public GetTerminalQueryHandlerTest() : base()
        {
            _handler = new GetTerminalQueryHandler(_appDatabase);
        }

        [Fact]
        public async Task Handle_GetValidTerminalsFormDb_ShouldNotBeNull()
        {
            var query = new GetTerminalQuery()
            {
                TerminalId = _appDatabase.terminals.FirstOrDefault().Id
            };

            var resault = await _handler.Handle(query, CancellationToken.None);

            resault.ShouldNotBeNull();
        }

        [Fact]
        public async Task Handle_GetNotValidTerminalsFormDb_ShouldBeNull()
        {
            var query = new GetTerminalQuery()
            {
                TerminalId = "n843hd-fn349n4f3-34fn934"
            };

            var resault = await _handler.Handle(query, CancellationToken.None);

            resault.ShouldBeNull();
        }
    }
}
