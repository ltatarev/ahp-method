using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.Model;
using AHP.Model.Common;
using AHP.Repository.Common;

namespace AHP.Repository
{
	class AlternativeRepository : IAlternativeRepository
	{
        //Body of class

         #region Constructor

            public AlternativeRepository(IAHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private IAHPContext Context { get; set; }

        #endregion Properties

        #region Methods

      //-----CRUD needs to be added-----

        #endregion Methods
	}
}
