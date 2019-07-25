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

        private AHPContext Context { get; set; }

        public UnitOfWork()
        {
            
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                Context.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                Context.Set<T>().Attach(entity);
                Context.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(string ID) where T : class
        {
            var entity = Context.Set<T>().Find(ID);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await Context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }
      
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
