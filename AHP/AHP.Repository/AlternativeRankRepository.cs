using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.DAL.Entities;
using AHP.Model;
using AHP.Model.Common;
using AHP.Model.Common.Model_Interfaces;
using AHP.Repository.Common;
using AutoMapper;

namespace AHP.Repository
{
	class AlternativeRankRepository : IAlternativeRankRepository
	{       
        #region Constructor
            public AlternativeRankRepository(AHPContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        #endregion Constructor

        #region Properties    
        private IMapper Mapper;
        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods               

        public async Task<List<IAlternativeRankModel>> GetAlternativeRanks(int pageNumber, int pageSize=10)
        {
            var alternativeRanks = await Context.AlternativeRanks.OrderBy(ar => ar.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return Mapper.Map<List<IAlternativeRankModel>>(alternativeRanks);
        }

        public async Task<IAlternativeRankModel> GetAlternativeRankByIdAsync(int alterRankId)
        {
            var alterRank = await Context.AlternativeRanks.FindAsync(alterRankId);
            return Mapper.Map<IAlternativeRankModel>(alterRank);
        }

        public IAlternativeRankModel InsertAlternativeRank(IAlternativeRankModel alterRank)
        {
            var mapped = Mapper.Map<Project>(alterRank);
            Context.Projects.Add(mapped);            
            return alterRank;
        }

        public async Task<bool> DeleteAlternativeRank(int alterRankId)
        {
            var alterRank = await Context.AlternativeRanks.FindAsync(alterRankId);
            Context.AlternativeRanks.Remove(alterRank);
            return true;
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion Methods
    }
}
