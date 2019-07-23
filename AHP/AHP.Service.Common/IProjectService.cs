using AHP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AHP.Service.Common
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectsAsync(int PageNumber);
        Task<Project> GetProjectByIdAsync(int ProjectId);
        Task<Project> AddProjectAsync(Project project);      
        
    }
}
