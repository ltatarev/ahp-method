using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.DAL.Entities;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Service
{
    public class ProjectService : IProjectService
    {
        #region Constructors
        public ProjectService(IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this.ProjectRepository = projectRepository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties
        protected IUnitOfWorkFactory uowFactory;
        protected IProjectRepository ProjectRepository { get; private set; }
        #endregion Properties

        #region Methods
        
       public async Task<bool> AddProjectAsync(IProjectModel project)
        {

            project.DateCreated = DateTime.Now;
            project.DateUpdated = DateTime.Now;
            await ProjectRepository.InsertProject(project);
          

            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await ProjectRepository.InsertProject(project);
                uow.Commit();
            }
            return true;
        }
        public async Task<List<IProjectModel>> GetProjects(int pageNumber, int pageSize = 10)
        {
            var Projects = await ProjectRepository.GetProjectsAsync(pageNumber, pageSize);
            return Projects;
        }

        public async Task<IProjectModel> CompareProjects(string projectName, string userName)
        {
            return await ProjectRepository.CompareProjects(projectName, userName);
        }

        public async Task<IProjectModel> GetProjectsByIdWithAandC(int id)
        {
            return await ProjectRepository.GetProjectsByIdWithAandC(id);
        }

        public async Task<int> CountProjects()
        {
            return await ProjectRepository.CountProjects();
        }


        #endregion Methods

    }
}
