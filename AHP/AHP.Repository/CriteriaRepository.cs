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
        public async Task<List<ICriteriaModel>> GetCriteriasAsync(int PageNumber, int PageSize = 10)
        {
            var criterias = await Context.Criterias.OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            var mapped = Mapper.Map<List<Criteria>, List<ICriteriaModel>>(criterias);
            return mapped;
        }

        public async Task<ICriteriaModel> GetCriteriaByIdAsync(int CriteriaId)
        {
            var criteria = await Context.Criterias.FindAsync(CriteriaId);
            return Mapper.Map<Criteria, ICriteriaModel>(criteria);
        }        

        public async Task<List<ICriteriaModel>> GetCriteriasByProjectId(int ProjectId, int PageNumber, int PageSize)
        {
            var criterias = await Context.Criterias.Where(c=>c.ProjectId==ProjectId).OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            var mapped = Mapper.Map<List<ICriteriaModel>>(criterias);
            return mapped;
        }

        public ICriteriaModel InsertCriteria(ICriteriaModel criteria)
        {
            var mapped = Mapper.Map<ICriteriaModel, Criteria>(criteria);
            Context.Criterias.Add(mapped);            
            return criteria;
        }

        public  List<ICriteriaModel> AddRange(List<ICriteriaModel> criteria)
        {
            Context.Criterias.AddRange(Mapper.Map<List<Criteria>>(criteria));
            return criteria;
        }

        public async Task<bool> DeleteCriteriaAsync(int CriteriaID)
        {
            var crit = await Context.Criterias.FindAsync(CriteriaID);
            Context.Criterias.Remove(crit);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }
        #endregion Methods
    }
}
