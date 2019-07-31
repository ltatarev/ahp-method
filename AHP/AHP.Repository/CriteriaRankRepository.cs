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
    class CriteriaRankRepository : ICriteriaRankRepository
    {
        
        #region Constructor
            public CriteriaRankRepository(AHPContext context, IMapper mapper)
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

        public async Task<List<ICriteriaRankModel>> GetCriteriaRanks(int pageNumber, int pageSize=10)
        {
            var critRanks = await Context.CriteriaRanks.OrderBy(cr => cr.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return Mapper.Map<List<ICriteriaRankModel>>(critRanks);
        }

        public async Task<ICriteriaRankModel> GetCriteriaRankById(Guid criteriaRankId)
        {
            var critRank = await Context.CriteriaRanks.FindAsync(criteriaRankId);
            return Mapper.Map<ICriteriaRankModel>(critRank);
        }      

        public async Task<ICriteriaRankModel> InsertCriteriaRank(ICriteriaRankModel criteriaRank)
        {
            var mapped = Mapper.Map<CriteriaRank>(criteriaRank);
            Context.CriteriaRanks.Add(mapped);
            await Context.SaveChangesAsync();
            return criteriaRank;
        }

        public async Task<List<ICriteriaRankModel>> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            var mapped = Mapper.Map<List<CriteriaRank>>(criteriaRanks);
            Context.CriteriaRanks.AddRange(mapped);
            await Context.SaveChangesAsync();
            return criteriaRanks;
        }

        public async Task<bool> DeleteCriteriaRank(Guid criterRankId)
        {
            var criteriaRank = await Context.CriteriaRanks.FindAsync(criterRankId);
            Context.CriteriaRanks.Remove(criteriaRank);
            await Context.SaveChangesAsync();
            return true;
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }



        #endregion Methods
    }
}
