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
        public CriteriaService(ICriteriaRepository repository, IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this._criteriaRepository = repository;
            this._uowFactory = uowFactory;
            this._projectRepository = projectRepository;
        }
        #endregion Constructors

        #region Properties      
        private IProjectRepository _projectRepository;
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
        public async Task<bool> DeleteCriteriaAsync(Guid id)
        {
            return await _criteriaRepository.DeleteCriteriaAsync(id);
        }
        public async Task<List<ICriteriaModel>> AddRange(List<ICriteriaModel> criteria)
        {
            //update status projekta
            var project = await _projectRepository.GetProjectByIdAsync(criteria[0].ProjectId);
            project.Status = 2;
            project.DateUpdated = DateTime.Now;

            var criteriasInDb = await _criteriaRepository.GetCriteriasByProjectId(criteria[0].ProjectId,1,100);
            var order = 1;           
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                foreach (var crit in criteria)
                {
                    crit.DateUpdated = DateTime.Now;
                    crit.DateCreated = DateTime.Now;
                    crit.Order = order;
                    order++;
                    //If criteria exists, update it                   
                    if (criteriasInDb.FindIndex(c => c.CriteriaId == crit.CriteriaId) >= 0)
                    {
                        await _criteriaRepository.UpdateCriteria(crit);                     
                    }
                    //If criteria doesn't exist, create new id and insert it to database
                    else
                    {
                        crit.CriteriaId = Guid.NewGuid();
                        crit.DateCreated = DateTime.Now;
                        await _criteriaRepository.InsertCriteria(crit);
                    }
                }
                await _projectRepository.UpdateProject(project);
                uow.Commit();
            }
            return criteria;
        }

        #endregion Methods

    }
}
