using AHP.DAL.Entities;
using AHP.Model.Common.Model_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AHP.Service.Common
{
    public interface IProjectService
    {
        Task<bool> AddProjectAsync(IProjectModel project);
        Task<List<IProjectModel>> GetProjects(int pageNumber, int pageSize);
        Task<IProjectModel> CompareProjects(string projectName, string userName);


    }
}
