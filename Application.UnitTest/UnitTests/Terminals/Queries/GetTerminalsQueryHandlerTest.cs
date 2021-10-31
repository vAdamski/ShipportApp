using Application.UnitTest.Common;
using ShipportApp.Application.Terminals.Queries.GetTerminals;
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
    public  class GetTerminalsQueryHandlerTest : CommandTestBase
    {
        private readonly GetTerminalsQueryHandler _handler;

        public GetTerminalsQueryHandlerTest()
        {
            _handler = new GetTerminalsQueryHandler(_appDatabase);
        }
    }
}
