using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        private bool disposed = false;
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
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transactionScope != null)
                    {
                        transactionScope.Dispose();
                    }
                }
                disposed = true;
            }
        }
    }
}
