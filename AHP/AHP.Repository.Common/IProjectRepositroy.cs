using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
    public interface IProjectRepository
    {
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting project
        //Example for checking if first project was added

        IEnumerable<Project> GetProjects();
        Project GetProjectById(int ProjectId);
        void InsertProject(Project project);
        void DeleteProject(int ProjectId);

        #endregion Methods
    }
}
