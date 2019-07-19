using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Repository.Common;

namespace AHP.Repository
{
	class ProjectRepository : IProjectRepository
	{
        //Body of class

         #region Constructor

            public ProjectRepository(IProjectRepository context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private IProjectRepository Context { get;  set; }

        #endregion Properties

        #region Methods

      //-----CRUD needs to be added-----

        #endregion Methods
	}
}
