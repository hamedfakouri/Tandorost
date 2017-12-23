using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticketing.Config;

namespace Framework.Testing
{
    public abstract class BasePersistanceTest
    {
        protected TransactionScope Scope;

        [TestInitialize]
        public void SetupTransaction()
        {
            Scope = new TransactionScope();
        }

        [TestCleanup]
        public void DisposeTransaction()
        {
            Scope.Dispose();
        }
    }
}
