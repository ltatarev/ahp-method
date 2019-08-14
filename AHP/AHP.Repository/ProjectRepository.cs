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
            this._context = context;
            this._mapper = mapper;
        }

        #endregion Constructor

        #region Properties

        private IMapper _mapper;
        private AHPContext _context;

        #endregion Properties

        #region Methods          
        public async Task<List<IProjectModel>> GetProjectsAsync(int PageNumber, int PageSize = 10)
        {
            var projects = await _context.Projects.OrderBy(P => P.DateCreated).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();            
            return _mapper.Map<List<IProjectModel>>(projects);
        }

        public async Task<IProjectModel> CompareProjects(string projectName, string userName)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectName == projectName && p.Username == userName);
            return _mapper.Map<IProjectModel>(project);
        }

        public async Task<IProjectModel> GetProjectsByIdWithAandC(Guid id)
        {
            var project = await _context.Projects.Where(p => p.ProjectId == id).
                                                 Include(p => p.Alternatives).
                                                 Include(p => p.Criterias.Select(c => c.AlternativeRanks)).
                                                 Include(p => p.Criterias.Select(c => c.CriteriaRanks)).
                                                 FirstOrDefaultAsync();
           
            return _mapper.Map<IProjectModel>(project);
        }

        public async Task<IProjectModel> GetProjectByIdAsync(Guid projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            return _mapper.Map<Project, IProjectModel>(project);
        }

        public async Task<IProjectModel> InsertProject(IProjectModel project)
        {
            var mapped = _mapper.Map<IProjectModel, Project>(project);
            _context.Projects.Add(mapped);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            var proj = await _context.Projects.FindAsync(projectId);
            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IProjectModel> UpdateProject(IProjectModel project)
        {
            var projectInDb = await _context.Projects.FindAsync(project.ProjectId);
            _context.Entry(projectInDb).CurrentValues.SetValues(_mapper.Map<Project>(project));
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<int> CountProjects() => await _context.Projects.CountAsync();
               
        
        #endregion Methods
    }
}
