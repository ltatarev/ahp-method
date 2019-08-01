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
            this._context = context;
            this._mapper = mapper;
        }
        #endregion Constructor
        #region Properties        
        private IMapper _mapper;
        private AHPContext _context;

        #endregion Properties

        #region Methods       

        public async Task<List<ICriteriaRankModel>> GetCriteriaRanks(int pageNumber, int pageSize=10)
        {
            var critRanks = await _context.CriteriaRanks.OrderBy(cr => cr.DateCreated).
                                                        Skip((pageNumber - 1) * pageSize).
                                                        Take(pageSize).
                                                        ToListAsync();

            return _mapper.Map<List<ICriteriaRankModel>>(critRanks);
        }

        public async Task<ICriteriaRankModel> GetCriteriaRankById(Guid criteriaRankId)
        {
            var critRank = await _context.CriteriaRanks.FindAsync(criteriaRankId);
            return _mapper.Map<ICriteriaRankModel>(critRank);
        }      

        public async Task<ICriteriaRankModel> InsertCriteriaRank(ICriteriaRankModel criteriaRank)
        {
            var mapped = _mapper.Map<CriteriaRank>(criteriaRank);
            _context.CriteriaRanks.Add(mapped);
            await _context.SaveChangesAsync();
            return criteriaRank;
        }

        public async Task<List<ICriteriaRankModel>> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            var mapped = _mapper.Map<List<CriteriaRank>>(criteriaRanks);
            _context.CriteriaRanks.AddRange(mapped);
            await _context.SaveChangesAsync();
            return criteriaRanks;
        }

        public async Task<bool> DeleteCriteriaRank(Guid criterRankId)
        {
            var criteriaRank = await _context.CriteriaRanks.FindAsync(criterRankId);
            _context.CriteriaRanks.Remove(criteriaRank);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        
        #endregion Methods
    }
}
