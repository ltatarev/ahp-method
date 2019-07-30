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
	class AlternativeRepository : IAlternativeRepository
	{        
        #region Constructor

            public AlternativeRepository(AHPContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        #endregion Constructor
        #region Properties

        //Context was protected
        private IMapper Mapper;
        private AHPContext Context { get; set; }

        #endregion Properties
        #region Methods   
        public async Task<List<IAlternativeModel>> GetAlternativesAsync(int pageNumber, int pageSize=10)
        {
            var alternatives = await Context.Alternatives.OrderBy(a => a.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return Mapper.Map<List<IAlternativeModel>>(alternatives);
        }

        public async Task<IAlternativeModel> GetAlternativeById(int alternativeId)
        {
            var alternative = await Context.Alternatives.FindAsync(alternativeId);
            return Mapper.Map<IAlternativeModel>(alternative);
        }                

        public async Task<List<IAlternativeModel>> GetAlternativesByProjectId(int ProjectId, int pageNumber, int pageSize=10)
        {
            var alternatives = await Context.Alternatives.Where(a => a.ProjectId == ProjectId).OrderBy(a => a.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return Mapper.Map<List<IAlternativeModel>>(alternatives);
        }                

        public async Task<IAlternativeModel> InsertAlternative(IAlternativeModel alternative)
        {
            var mapped = Mapper.Map<Alternative>(alternative);
            Context.Alternatives.Add(mapped);
            await Context.SaveChangesAsync();
            return alternative;
        }
        public async Task<List<IAlternativeModel>> AddRange(List<IAlternativeModel> alternatives)
        {
            var mapped = Mapper.Map<List<Alternative>>(alternatives);
            Context.Alternatives.AddRange(mapped);
            await Context.SaveChangesAsync();
            return alternatives;
        }

        public async Task<bool> DeleteAlternative(int AlternativeId)
        {
            var alternative = await Context.Alternatives.FindAsync(AlternativeId);
            Context.Alternatives.Remove(alternative);
            await Context.SaveChangesAsync();
            return true;
        }
        public async Task<IAlternativeModel> UpdateAlternative(IAlternativeModel alternative)
        {
            var alternativeInDb = await Context.Alternatives.FindAsync(alternative.AlternativeId);
            Context.Entry(alternativeInDb).CurrentValues.SetValues(Mapper.Map<Alternative>(alternative));
            await Context.SaveChangesAsync();

            return alternative;

        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion Methods
    }
}
