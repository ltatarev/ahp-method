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
    class ProjectRepository : Repository<IProjectModel>, IProjectRepository
    {
        #region Constructor

        public ProjectRepository(AHPContext context, IMapper mapper) : base(context)
        {
            this.Mapper = mapper;
        }

        #endregion Constructor

        #region Properties

        public IMapper Mapper { get; set; }

        #endregion Properties

        #region Methods          
        public async Task<List<IProjectModel>> GetProjectsAsync(int PageNumber, int PageSize = 10)
        {
            var projects = await Context.Projects.OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();
            var mapped = Mapper.Map<List<Project>, List<IProjectModel>>(projects);
            return mapped;
        }

        public async Task<IProjectModel> GetProjectByIdAsync(int ProjectId)
        {
            var project = await Context.Projects.FindAsync(ProjectId);
            return Mapper.Map<Project, IProjectModel>(project);
        }

        public bool InsertProject(IProjectModel project)
        {
            using (var unitOfWork = new UnitOfWork(Context, Mapper))
            {
                var mapped = Mapper.Map<Project>(project);
                
                unitOfWork.Projects.Add(project);

                unitOfWork.Complete();
                return true;
            }
        }

        public async Task<bool> DeleteProject(int ProjectId)
        {
            var project = await Context.Projects.FindAsync(ProjectId);
            Context.Projects.Remove(project);
            return true;
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion Methods
	}
}
