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
	class ProjectRepository : IProjectRepository
	{
        //Body of class

         #region Constructor

            public ProjectRepository(IAHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private IAHPContext Context { get;  set; }

        #endregion Properties

        #region Methods

        //Methods in interface needs to be initialized
    
        public IEnumerable<Project> GetProjects()
        {
            return Context.Projects.ToList();
        }

         public Project GetProjectById(int ProjectId)
        {
            return Context.Projects.Find(ProjectId);
        }

        public void InsertProject(Project project)
        {
            Context.Projects.Add(project);
     //       Context.SaveChanges();
        }

        public void DeleteProject(int ProjectId)
        {
            Project project = Context.Projects.Find(ProjectId);
            Context.Projects.Remove(project);
     //       Context.SaveChanges();
        }

        #endregion Methods
	}
}
