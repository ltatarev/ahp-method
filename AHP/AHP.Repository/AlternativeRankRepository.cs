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
            this._context = context;
            this._mapper = mapper;
        }
        #endregion Constructor

        #region Properties    
        private IMapper _mapper;
        private AHPContext _context;

        #endregion Properties

        #region Methods               

        public async Task<List<IAlternativeRankModel>> GetAlternativeRanks(int pageNumber, int pageSize=10)
        {
            var alternativeRanks = await _context.AlternativeRanks.OrderBy(ar => ar.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<List<IAlternativeRankModel>>(alternativeRanks);
        }

        public async Task<IAlternativeRankModel> GetAlternativeRankByIdAsync(Guid alterRankId)
        {
            var alterRank = await _context.AlternativeRanks.FindAsync(alterRankId);
            return _mapper.Map<IAlternativeRankModel>(alterRank);
        }

        public async Task<IAlternativeRankModel> InsertAlternativeRank(IAlternativeRankModel alterRank)
        {
            var mapped = Mapper.Map<Project>(alterRank);
            _context.Projects.Add(mapped);
            await _context.SaveChangesAsync();
            return alterRank;
        }

        public async Task<bool> DeleteAlternativeRank(Guid alterRankId)
        {
            var alterRank = await _context.AlternativeRanks.FindAsync(alterRankId);
            _context.AlternativeRanks.Remove(alterRank);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<IAlternativeRankModel>> AddRange(List<IAlternativeRankModel> alternativeRanks)
        {
            var mapped = _mapper.Map<List<AlternativeRank>>(alternativeRanks);
            _context.AlternativeRanks.AddRange(mapped);
            await _context.SaveChangesAsync();
            return alternativeRanks;
        }

        
        #endregion Methods
    }
}
