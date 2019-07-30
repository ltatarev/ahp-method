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
        public CriteriaRankService(ICriteriaRankRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this.Repository = repository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors
        #region Properties
        protected ICriteriaRankRepository Repository { get; private set; }
        protected IUnitOfWorkFactory uowFactory;
        #endregion Properties

        public async Task<bool> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await Repository.AddRange(criteriaRanks);
                uow.Commit();
            }
            return true;
        }


    }
}
