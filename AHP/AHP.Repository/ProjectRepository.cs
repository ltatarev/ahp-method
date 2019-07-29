using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.DAL.Entities;
using AHP.Model;
using AHP.Model.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository
{
    class ProjectRepository : IProjectRepository
    {
        #region Constructor

        public ProjectRepository(AHPContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        #endregion Constructor

        #region Properties

        public IMapper Mapper { get; set; }
        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods          
        public async Task<List<IProjectModel>> GetProjectsAsync(int PageNumber, int PageSize = 10)
        {
            var projects = await Context.Projects.OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            var mapped = Mapper.Map<List<Project>, List<IProjectModel>>(projects);
            return mapped;
        }

        public async Task<IProjectModel> CompareProjects(string projectName, string userName)
        {
            var project = await Context.Projects.Where(p => p.ProjectName == projectName).Where(p => p.Username == userName).FirstOrDefaultAsync();
            return Mapper.Map<IProjectModel>(project);
        }

        public async Task<IProjectModel> GetProjectByIdAsync(int ProjectId)
        {
            var project = await Context.Projects.FindAsync(ProjectId);
            return Mapper.Map<Project, IProjectModel>(project);
        }

        public IProjectModel InsertProject(IProjectModel project)
        {
            var mapped = Mapper.Map<IProjectModel, Project>(project);
            Context.Projects.Add(mapped);
            return project;
        }

        public async Task<bool> DeleteProject(int ProjectId)
        {
            var proj = await Context.Projects.FindAsync(ProjectId);
            Context.Projects.Remove(proj);
            return true;
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion Methods
    }
}
