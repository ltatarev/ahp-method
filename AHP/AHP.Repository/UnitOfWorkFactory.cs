using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.Repository.Common;
using AutoMapper;

namespace AHP.Repository
{
    class UnitOfWorkFactory : IUnitOfWorkFactory
    {

        private AHPContext _context;
        public UnitOfWorkFactory(AHPContext context, IMapper mapper)
        {
            _context = context;
            this.Mapper = mapper;
        }

        public IMapper Mapper { get; set; }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(_context, Mapper);
        }

    }
}
