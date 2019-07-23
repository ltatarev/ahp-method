using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.DAL.Entities;

namespace AHP.Service
{
    public class ProjectService : IProjectService
    {
        #region Constructors
        public ProjectService(IProjectRepository projectRepository)
        {
            this.ProjectRepository = projectRepository;
        }
        #endregion Constructors

        #region Properties
        protected IProjectRepository ProjectRepository { get; private set; }
        #endregion Properties

        #region Methods

        public async Task<Project> AddProjectAsync(Project project)
        {
            project.DateCreated = DateTime.Now;
            project.DateUpdated = DateTime.Now;
            ProjectRepository.InsertProject(project);
            await ProjectRepository.SaveAsync();
            return project;

        }
        public async Task<List<Project>> GetProjectsAsync(int PageNumber)
        {
            var Projects = await ProjectRepository.GetProjectsAsync(PageNumber);
            return Projects;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await ProjectRepository.GetProjectByIdAsync(id);
        }

        #endregion Methods

    }
}
