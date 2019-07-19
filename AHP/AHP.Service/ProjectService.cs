using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;

namespace AHP.Service
{
    public class ProjectService : IProjectService
    {
        #region Constructors
        public ProjectService(IProjectRepository repository)
        {
            this.Repository = repository;
        }
        #endregion Constructors

        #region Properties
        protected IProjectRepository Repository { get; private set; }
        #endregion Properties

        #region Methods

        //Add method

        #endregion Methods

    }
}
