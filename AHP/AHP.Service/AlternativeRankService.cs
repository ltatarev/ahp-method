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
    public class AlternativeRankService : IAlternativeRankService
    {
        #region Constructors
        public AlternativeRankService(IAlternativeRankRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this.Repository = repository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties
        protected IAlternativeRankRepository Repository { get; private set; }
        protected IUnitOfWorkFactory uowFactory;
        #endregion Properties

        #region Methods

        public async Task<bool> AddRange(List<IAlternativeRankModel> alternativeRanks)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await Repository.AddRange(alternativeRanks);
                await Repository.SaveAsync();
                uow.Commit();
            }
            return true;
        }

        #endregion Methods

    }
}
