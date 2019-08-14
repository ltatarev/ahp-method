using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.DAL.Entities;
using AHP.Model.Common.Model_Interfaces;
using AHP.Repository.Common;
using AutoMapper;

namespace AHP.Repository
{
	class AlternativeRepository : IAlternativeRepository
	{        
        #region Constructor

            public AlternativeRepository(AHPContext context, IMapper mapper)
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

        public async Task<IAlternativeModel> GetAlternativeById(Guid alternativeId)
        {
            var alternative = await _context.Alternatives.Where(a => a.AlternativeId == alternativeId).Include(a => a.Project).FirstOrDefaultAsync();
            return _mapper.Map<IAlternativeModel>(alternative);
        }                

        public async Task<List<IAlternativeModel>> GetAlternativesByProjectId(Guid projectId, int pageNumber, int pageSize=10)
        {
            var alternatives = await _context.Alternatives.Where(a => a.ProjectId == projectId).
                                                           OrderBy(a => a.Order).
                                                           Skip((pageNumber - 1) * pageSize).
                                                           Take(pageSize).
                                                           ToListAsync();

            return _mapper.Map<List<IAlternativeModel>>(alternatives);
        }                

        public async Task<IAlternativeModel> InsertAlternative(IAlternativeModel alternative)
        {
            var mapped = _mapper.Map<Alternative>(alternative);
            _context.Alternatives.Add(mapped);
            await _context.SaveChangesAsync();
            return alternative;
        }

        public async Task<List<IAlternativeModel>> AddRange(List<IAlternativeModel> alternatives)
        {
            var mapped = _mapper.Map<List<Alternative>>(alternatives);
            _context.Alternatives.AddRange(mapped);
            await _context.SaveChangesAsync();
            return alternatives;
        }

        public async Task<bool> DeleteAlternative(Guid alternativeId)
        {
            var alternative = await _context.Alternatives.FindAsync(alternativeId);
            _context.Alternatives.Remove(alternative);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IAlternativeModel> UpdateAlternative(IAlternativeModel alternative)
        {
            var alternativeInDb = await _context.Alternatives.FindAsync(alternative.AlternativeId);
            _context.Entry(alternativeInDb).CurrentValues.SetValues(_mapper.Map<Alternative>(alternative));
            await _context.SaveChangesAsync();

            return alternative;
        }

       
        #endregion Methods
    }
}
