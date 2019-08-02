using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Service
{
    public class ProjectService : IProjectService
    {
        #region Constructors
        public ProjectService(IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this._projectRepository = projectRepository;
            this._uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties
        protected IUnitOfWorkFactory _uowFactory;
        protected IProjectRepository _projectRepository;
        #endregion Properties

        #region Methods
        
       public async Task<IProjectModel> AddProjectAsync(IProjectModel project)
        {
            project.DateCreated = DateTime.Now;
            project.DateUpdated = DateTime.Now;
            project.Status = 0;
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _projectRepository.InsertProject(project);
                uow.Commit();
            }
            return project;
        }

        public async Task<List<IProjectModel>> GetProjects(int pageNumber, int pageSize = 10)
        {
            var projects = await _projectRepository.GetProjectsAsync(pageNumber, pageSize);
            return projects;
        }

        public async Task<IProjectModel> CompareProjects(string projectName, string userName)
        {
            return await _projectRepository.CompareProjects(projectName, userName);
        }

        public async Task<IProjectModel> GetProjectByIdAsync(Guid projectId)
        {
            return await _projectRepository.GetProjectByIdAsync(projectId);
        }

        public async Task<IProjectModel> GetProjectsByIdWithAandC(Guid id)
        {
            return await _projectRepository.GetProjectsByIdWithAandC(id);
        }

        public async Task<IProjectModel> Update(IProjectModel project)
        {
            var projectInDb = await _projectRepository.GetProjectByIdAsync(project.ProjectId);
            projectInDb.DateUpdated = DateTime.Now;
            projectInDb.Status = project.Status;

            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _projectRepository.UpdateProject(projectInDb);
                uow.Commit();
            }
            return projectInDb;
        }

        public async Task<int> CountProjects()
        {
            return await _projectRepository.CountProjects();
        }


        #endregion Methods

    }
}
