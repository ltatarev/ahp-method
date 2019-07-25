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
        public ProjectService(IProjectRepository projectRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.ProjectRepository = projectRepository;
            this.UnitOfWorkFactory = unitOfWorkFactory;
        }
        #endregion Constructors

        #region Properties
        protected IUnitOfWorkFactory UnitOfWorkFactory;
        protected IProjectRepository ProjectRepository { get; private set; }
        #endregion Properties

        #region Methods
        
       public async Task<IProjectModel>AddProjectAsync(IProjectModel project)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            // await unitOfWork.AddAsync(project);
            ProjectRepository.InsertProject(project);
            await ProjectRepository.SaveAsync();
            //  await unitOfWork.CommitAsync();
            return project;
        }
        public async Task<List<IProjectModel>> GetProjects(int pageNumber, int pageSize = 10)
        {
            var Projects =await ProjectRepository.GetProjectsAsync(pageNumber, pageSize);
            return Projects;
        }

        public async Task<IProjectModel> CompareProjects(string projectName, string userName)
        {
            return await ProjectRepository.CompareProjects(projectName, userName);
        }


        #endregion Methods

    }
}
