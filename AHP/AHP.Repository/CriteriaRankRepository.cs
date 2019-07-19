using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Repository.Common;

namespace AHP.Repository
{
    class CriteriaRankRepository : ICriteriaRankRepository
    {
         //Body of class

         #region Constructor

            public CriteriaRankRepository(ICriteriaRankRepository context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private ICriteriaRankRepository Context { get; set; }

        #endregion Properties

        #region Methods

      //-----CRUD needs to be added-----

        #endregion Methods
    }
}
