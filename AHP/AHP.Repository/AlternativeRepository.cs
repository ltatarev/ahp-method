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
	class AlternativeRepository : IAlternativeRepository
	{
        //Body of class

         #region Constructor

            public AlternativeRepository(IAHPContext context)
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

        public IEnumerable<Alternative> GetAlternatives()
        {
            return Context.Alternatives.ToList();
        }

        public Alternative GetAlternativeById(int AlternativeId)
        {
            return Context.Alternatives.Find(AlternativeId);
        }

        //Method for cheching if projectId in criteria is same as projectId in project

        public void GetAlternativeByProjectId(int ProjectId)
        {

            Project projectId = Context.Projects.Find(ProjectId);
            Alternative alternativeProjectId = Context.Alternatives.Find(ProjectId);

            // project.Equals(criteriaProjectId); -- checks if objects are same

            if (projectId.Equals(alternativeProjectId))
            {
                Context.Criterias.Find(alternativeProjectId);
            }
        }

        public void InsertAlternative(Alternative alternative)
        {
            Context.Alternatives.Add(alternative);
        //    Context.SaveChanges();
        }

        public void DeleteAlternative(int AlternativeId)
        {
            Alternative alternative = Context.Alternatives.Find(AlternativeId);
            Context.Alternatives.Remove(alternative);
         //   Context.SaveChanges();
        }

        #endregion Methods
    }
}
