using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.Model;
using AHP.Model.Common;
using AHP.Repository.Common;

namespace AHP.Repository
{
	class CriteriaRepository : ICriteriaRepository
	{
         //Body of class

         #region Constructor

            public CriteriaRepository(IAHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private IAHPContext Context { get; set; }

        #endregion Properties

        #region Methods

        //Methods in interface needs to be initialized

        public IEnumerable<Criteria> GetCriterias()
        {
            return Context.Criterias.ToList();
        }

        public Criteria GetCriteriaById(int CriteriaId)
        {
            return Context.Criterias.Find(CriteriaId);
        }

        //Method for cheching if projectId in criteria is same as projectId in project

        public void GetCritriaByProjectId(int ProjectId)
        {

            Project projectId = Context.Projects.Find(ProjectId);
            Criteria criteriaProjectId = Context.Criterias.Find(ProjectId);

            // project.Equals(criteriaProjectId); -- checks if objects are same

            if (projectId.Equals(criteriaProjectId))
            {
                Context.Criterias.Find(criteriaProjectId);
            }
        }
        public void InsertCriteria(Criteria Criteria)
        {
            Context.Criterias.Add(Criteria);
        //    Context.SaveChanges();
        }

        public void DeleteCriteria(int CriteriaId)
        {
            Criteria criteria = Context.Criterias.Find(CriteriaId);
            Context.Criterias.Remove(criteria);
       //     Context.SaveChanges();
        }

        #endregion Methods
    }
}
