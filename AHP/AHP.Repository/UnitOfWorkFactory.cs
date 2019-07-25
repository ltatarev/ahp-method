using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.Repository.Common;

namespace AHP.Repository
{
    class UnitOfWorkFactory : IUnitOfWorkFactory
    {

        private AHPContext _context;
        public UnitOfWorkFactory(AHPContext context)
        {
            _context = context;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(_context);
        }

    }
}
