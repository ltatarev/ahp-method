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
using AHP.Repository.Common;

namespace AHP.Repository
{
	class CriteriaRepository : ICriteriaRepository
	{
        //Body of class

        #region Constructor

            public CriteriaRepository(AHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods

        //Methods for Criteria class

        public async Task<List<Criteria>> GetCriteriasAsync()
        {
            return await Context.Criterias.ToListAsync();
        }

        public async Task<Criteria> GetCriteriaByIdAsync(int CriteriaId)
        {
            return await Context.Criterias.FindAsync(CriteriaId);
        }

        //Method for cheching if criteria is from specific project

        public async Task<List<Criteria>> GetCritriaByProjectIdAsync(int ProjectId)
        {
            List<Criteria> criterias = await Context.Criterias.ToListAsync();
            List<Criteria> results = new List<Criteria>();
            foreach(var crit in criterias)
            {
                if (crit.ProjectId == ProjectId)
                    results.Add(crit);
            }
            return results;
           
        }

        public async void InsertCriteriaAsync(Criteria Criteria)
        {
            Context.Criterias.Add(Criteria);
            await Context.SaveChangesAsync();
        }

        public async void DeleteCriteriaAsync(int CriteriaId)
        {
            Criteria criteria = await Context.Criterias.FindAsync(CriteriaId);
            Context.Criterias.Remove(criteria);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
