using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository.Common
{
    public interface IProjectRepository : IRepository<Project>
    {
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting project
        //Example for checking if first project was added

        Task<List<IProjectModel>> GetProjectsAsync(int PageNumber, int PageSize = 10);
        Task<IProjectModel> GetProjectByIdAsync(int ProjectId);
        bool InsertProject(IProjectModel project);
        Task<bool> DeleteProject(int ProjectId);
        Task<int> SaveAsync();

        #endregion Methods
    }
}
