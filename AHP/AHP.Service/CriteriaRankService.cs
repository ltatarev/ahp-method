using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

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

        public async Task<bool> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            foreach (var cr in criteriaRanks)
            {
                cr.DateCreated = DateTime.Now;
                cr.DateUpdated = DateTime.Now;
            }
            Repository.AddRange(criteriaRanks);
            await Repository.SaveAsync();
            return true;
        }


    }
}
