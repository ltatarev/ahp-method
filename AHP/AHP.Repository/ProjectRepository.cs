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

        
        private AHPContext Context { get;  set; }

        #endregion Properties

        #region Methods
        
    
        public async Task<List<Project>> GetProjectsAsync(int PageNumber, int PageSize=10)
        {
            var projects = await Context.Projects.OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            return projects;
        }

         public async Task<Project> GetProjectByIdAsync(int ProjectId)
        {
            var Project = await Context.Projects.FindAsync(ProjectId);
            return Project;

        }

        public void InsertProject(Project project)
        {
            Context.Projects.Add(project);
            Context.SaveChanges();
        }

        public void DeleteProject(int ProjectId)
        {
            Project project = Context.Projects.Find(ProjectId);
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
