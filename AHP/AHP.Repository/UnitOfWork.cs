using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AHP.DAL;
using AHP.Repository.Common;

namespace AHP.Repository
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly TransactionScope transactionScope;
        private bool dispose = false;

        public UnitOfWork()
        {
            transactionScope = new TransactionScope(
                 TransactionScopeOption.RequiresNew,
                 new TransactionOptions()
                 {
                     IsolationLevel = IsolationLevel.ReadCommitted
                 },
                 TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Commit()
        {
            transactionScope.Complete();
        }


        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    if (transactionScope != null)
                    {
                        transactionScope.Dispose();
                    }
                }
                dispose = true;
            }
        }

    }
}
