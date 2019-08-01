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
        public AlternativeRankService(IAlternativeRankRepository alternativeRankService, IUnitOfWorkFactory uowFactory)
        {
            this._alternativeRankRepository = alternativeRankService;           
            this._uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties
        private IAlternativeRankRepository _alternativeRankRepository;
        private IUnitOfWorkFactory _uowFactory;
        #endregion Properties

        #region Methods

        public async Task<bool> AddRange(List<IAlternativeRankModel> alternativeRanks)
        {
            foreach(var ar in alternativeRanks)
            {
                ar.DateCreated = DateTime.Now;
                ar.DateUpdated = DateTime.Now;
                ar.AlternativeRankId = Guid.NewGuid();
            }
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _alternativeRankRepository.AddRange(alternativeRanks);
                uow.Commit();
            }
            return true;
        }

        #endregion Methods

    }
}
