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
	class ProjectRepository : IProjectRepository
	{
        //Body of class

        #region Constructor

            public ProjectRepository(AHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private AHPContext Context { get;  set; }

        #endregion Properties

        #region Methods

        //Methods for Project class
    
        public async Task<List<Project>> GetProjectsAsync()
        {
            return await Context.Projects.ToListAsync();
        }

         public async Task<Project> GetProjectByIdAsync(int ProjectId)
        {
            return await Context.Projects.FindAsync(ProjectId);
        }

        public void InsertProject(Project project)
        {
            Context.Projects.Add(project);
            Context.SaveChanges();
        }

        public async void DeleteProjectAsync(int ProjectId)
        {
            Project project = await Context.Projects.FindAsync(ProjectId);
            Context.Projects.Remove(project);
            Context.SaveChanges();
        }

        #endregion Methods
	}
}
