using Moq;
using ShipportApp.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly AppDatabase _appDatabase;
        protected readonly Mock<AppDatabase> _mockDatabase;

        public CommandTestBase()
        {
            _mockDatabase = AppDatabaseFactory.Create();
            _appDatabase = _mockDatabase.Object;
        }


        public void Dispose()
        {
            //Delete database from DbContext
        }
    }
}
