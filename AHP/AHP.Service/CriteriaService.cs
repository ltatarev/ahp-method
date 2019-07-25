using System.Collections.Generic;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

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

        public async Task<bool> AddCriteriaAsync(ICriteriaModel criteria)
        {
            Repository.InsertCriteria(criteria);
            await Repository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteCriteria(int criteriaId)
        {
            await Repository.DeleteCriteriaAsync(criteriaId);
            await Repository.SaveAsync();
            return true;
        }
        public async Task<List<ICriteriaModel>> GetCriterias(int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetCriteriasAsync(pageNumber, pageSize);
            return criterias;
        }
        public async Task<List<ICriteriaModel>> GetCriteriasByProjectId(int projectId,int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetCriteriasByProjectId(projectId, pageNumber, pageSize);
            return criterias;
        }



        #endregion Methods

    }
}
