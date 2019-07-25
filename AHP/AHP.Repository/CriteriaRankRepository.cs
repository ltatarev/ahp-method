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

        public async Task<ICriteriaRankModel> GetCriteriaRankById(int criteriaRankId)
        {
            var critRank = await Context.CriteriaRanks.FindAsync(criteriaRankId);
            return Mapper.Map<ICriteriaRankModel>(critRank);
        }      

        public ICriteriaRankModel InsertCriteriaRank(ICriteriaRankModel criteriaRank)
        {
            var mapped = Mapper.Map<CriteriaRank>(criteriaRank);
            Context.CriteriaRanks.Add(mapped);
            return criteriaRank;
        }

        public List<ICriteriaRankModel> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            Context.CriteriaRanks.AddRange(Mapper.Map<List<CriteriaRank>>(criteriaRanks));
            return criteriaRanks;
        }

        public async Task<bool> DeleteCriteriaRank(int criterRankId)
        {
            var criteriaRank = await Context.CriteriaRanks.FindAsync(criterRankId);
            Context.CriteriaRanks.Remove(criteriaRank);
            return true;
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }



        #endregion Methods
    }
}
