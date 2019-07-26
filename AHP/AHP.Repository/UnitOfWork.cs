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
using AutoMapper;

namespace AHP.Repository
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly AHPContext Context;
      
        public UnitOfWork(AHPContext context, IMapper mapper)
        {
            Context = context;
            Projects = new ProjectRepository(Context, mapper);
            this.Mapper = mapper;
        }

        public IMapper Mapper { get; set; }
        public IProjectRepository Projects { get; private set; }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
