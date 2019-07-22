using System;
using System.Collections.Generic;
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

        public IEnumerable<Criteria> GetCriterias()
        {
            return Context.Criterias.ToList();
        }

        public Criteria GetCriteriaById(int CriteriaId)
        {
            return Context.Criterias.Find(CriteriaId);
        }

        //Method for cheching if criteria is from specific project

        public IEnumerable<Criteria> GetCritriaByProjectId(int ProjectId)
        {
            List<Criteria> criterias = Context.Criterias.ToList();
            List<Criteria> results = new List<Criteria>();
            foreach(var crit in criterias)
            {
                if (crit.ProjectId == ProjectId)
                    results.Add(crit);
            }
            return results;
           
        }

        public void InsertCriteria(Criteria Criteria)
        {
            Context.Criterias.Add(Criteria);
            Context.SaveChanges();
        }

        public void DeleteCriteria(int CriteriaId)
        {
            Criteria criteria = Context.Criterias.Find(CriteriaId);
            Context.Criterias.Remove(criteria);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
