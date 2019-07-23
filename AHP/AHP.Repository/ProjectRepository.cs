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
    
        public async Task<List<Project>> GetProjectsAsync(int PageNumber, int PageSize = 10)
        {
            var projects = await Context.Projects.OrderBy(
                P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            return projects;
        }

         public async Task<Project> GetProjectByIdAsync(int ProjectId)
        {
            var projects = await Context.Projects.FindAsync(ProjectId);
            return projects;
        }

        public async void InsertProjectAsync(Project project)
        {
            Context.Projects.Add(project);
            await Context.SaveChangesAsync();
        }

        public async void DeleteProjectAsync(int ProjectId)
        {
            Project project = await Context.Projects.FindAsync(ProjectId);
            Context.Projects.Remove(project);
            Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion Methods
    }
}
