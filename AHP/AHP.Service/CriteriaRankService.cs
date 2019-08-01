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
        public CriteriaRankService(ICriteriaRankRepository criteriaRankRepository, IUnitOfWorkFactory uowFactory)
        {
            this._criteriaRankRepository = criteriaRankRepository;
            this._uowFactory = uowFactory;
        }
        #endregion Constructors
        #region Properties
        protected ICriteriaRankRepository _criteriaRankRepository { get; private set; }
        protected IUnitOfWorkFactory _uowFactory;
        #endregion Properties

        public async Task<bool> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {

            foreach (var cr in criteriaRanks)
            {
                cr.DateCreated = DateTime.Now;
                cr.DateUpdated = DateTime.Now;
                cr.CriteriaRankId = Guid.NewGuid();                
            }

            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _criteriaRankRepository.AddRange(criteriaRanks);
                uow.Commit();
            }

            return true;
        }


    }
}
