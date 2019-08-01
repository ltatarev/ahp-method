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
	class CriteriaRepository : ICriteriaRepository
	{     
        #region Constructor

            public CriteriaRepository(AHPContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        #endregion Constructor

        #region Properties

        //Context was protected
        private IMapper _mapper;
        private AHPContext _context;

        #endregion Properties

        #region Methods
        public async Task<List<ICriteriaModel>> GetCriteriasAsync(int pageNumber, int pageSize = 10)
        {
            var criterias = await _context.Criterias.OrderBy(P => P.DateCreated).
                                                     Skip((pageNumber - 1) * pageSize).
                                                     Take(pageSize).
                                                     ToListAsync();

            var mapped = _mapper.Map<List<Criteria>, List<ICriteriaModel>>(criterias);
            return mapped;
        }

        public async Task<ICriteriaModel> GetCriteriaByIdAsync(Guid criteriaId)
        {
            var criteria = await _context.Criterias.FindAsync(criteriaId);
            return _mapper.Map<Criteria, ICriteriaModel>(criteria);
        }        

        public async Task<List<ICriteriaModel>> GetCriteriasByProjectId(Guid projectId, int pageNumber, int pageSize)
        {
            var criterias = await _context.Criterias.Where(c=>c.ProjectId==projectId).
                                                     OrderBy(P => P.DateCreated).
                                                     Skip((pageNumber - 1) * pageSize).
                                                     Take(pageSize).
                                                     ToListAsync();

            var mapped = _mapper.Map<List<ICriteriaModel>>(criterias);
            return mapped;
        }

        //gets criteria with lazy loaded CriteriaRanks and AlternativeRanks
        public async Task<List<ICriteriaModel>> GetCriteriasByProjectIdWithCRaAR(Guid projectId)
        {
            var criterias = await _context.Criterias.Where(c => c.ProjectId == projectId).Include(c => c.AlternativeRanks).Include(c => c.CriteriaRanks).ToListAsync();
            var mapped = _mapper.Map<List<ICriteriaModel>>(criterias);
            return mapped;
        }  

        public async Task<ICriteriaModel> InsertCriteria(ICriteriaModel criteria)
        {
            var mapped = _mapper.Map<Criteria>(criteria);
            _context.Criterias.Add(mapped);
            await _context.SaveChangesAsync();
            return criteria;
        }

        public async Task<List<ICriteriaModel>> AddRange(List<ICriteriaModel> criteria)
        {
            var mapped = _mapper.Map<List<Criteria>>(criteria);
            _context.Criterias.AddRange(mapped);
            await _context.SaveChangesAsync();
            return criteria;
        }

        public async Task<bool> DeleteCriteriaAsync(Guid criteriaID)
        {
            var crit = await _context.Criterias.FindAsync(criteriaID);
            _context.Criterias.Remove(crit);
            await _context.SaveChangesAsync();
            return true;
        }

       
        #endregion Methods
    }
}
