using System.Collections.Generic;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;
using System;

namespace AHP.Service
{
    public class CriteriaService : ICriteriaService
    {
        #region Constructors
        public CriteriaService(ICriteriaRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this._criteriaRepository = repository;
            this._uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties        
        private ICriteriaRepository _criteriaRepository;
        private IUnitOfWorkFactory _uowFactory; 
        #endregion Properties

        #region Methods

        public async Task<ICriteriaModel> AddCriteriaAsync(ICriteriaModel criteria)
        {
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                criteria.CriteriaId = Guid.NewGuid();
                await _criteriaRepository.InsertCriteria(criteria);
                uow.Commit();
            }
            return criteria;
        }

        public async Task<bool> DeleteCriteria(Guid criteriaId)
        {
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _criteriaRepository.DeleteCriteriaAsync(criteriaId);
                uow.Commit();
            }
            return true;
        }

        public async Task<List<ICriteriaModel>> GetCriterias(int pageNumber, int pageSize = 10)
        {
            var criterias = await _criteriaRepository.GetCriteriasAsync(pageNumber, pageSize);
            return criterias;
        }

        public async Task<List<ICriteriaModel>> GetCriteriasByProjectId(Guid projectId,int pageNumber, int pageSize = 10)
        {
            var criterias = await _criteriaRepository.GetCriteriasByProjectId(projectId, pageNumber, pageSize);
            return criterias;
        }

        public async Task<List<ICriteriaModel>> GetCriteriasByProjectIdWithCRaAR(Guid projectId)
        {
            var criterias = await _criteriaRepository.GetCriteriasByProjectIdWithCRaAR(projectId);
            return criterias;
        }

        public async Task<List<ICriteriaModel>> AddRange(List<ICriteriaModel> criteria)
        {            
            var order = 1;
            foreach (var crit in criteria)
            {
                crit.DateCreated = DateTime.Now;
                crit.DateUpdated = DateTime.Now;
                crit.CriteriaId = Guid.NewGuid();
                crit.Order = order;
                order++;
            }
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _criteriaRepository.AddRange(criteria);
                uow.Commit();
            }
            return criteria;
        }

        #endregion Methods

    }
}
