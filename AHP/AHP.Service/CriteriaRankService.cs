using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;

namespace AHP.Service
{
    public class CriteriaRankService : ICriteriaRankService
    {
        #region Constructors
        public CriteriaRankService(ICriteriaRankRepository repository)
        {
            this.Repository = repository;
        }
        #endregion Constructors
        #region Properties
        protected ICriteriaRankRepository Repository { get; private set; }
        #endregion Properties

       

    }
}
