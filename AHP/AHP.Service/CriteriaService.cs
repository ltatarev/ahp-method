using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;

namespace AHP.Service
{
    public class CriteriaService : ICriteriaService
    {
        #region Constructors
        public CriteriaService(ICriteriaRepository repository)
        {
            this.Repository = repository;
        }
        #endregion Constructors

        #region Properties
        protected ICriteriaRepository Repository { get; private set; }
        #endregion Properties

        #region Methods

        //Add method

        #endregion Methods

    }
}
