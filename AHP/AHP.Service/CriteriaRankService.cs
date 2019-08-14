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
        public CriteriaRankService(ICriteriaRankRepository criteriaRankRepository, ICriteriaRepository criteriaRepository, IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this._criteriaRankRepository = criteriaRankRepository;
            this._projectRepository = projectRepository;
            this._criteriaRepository = criteriaRepository;
            this._uowFactory = uowFactory;            
        }
        #endregion Constructors
        #region Properties
        private IProjectRepository _projectRepository;
        private ICriteriaRankRepository _criteriaRankRepository;
        private ICriteriaRepository _criteriaRepository;
        private IUnitOfWorkFactory _uowFactory;
        #endregion Properties

        public async Task<bool> AddRange(List<ICriteriaRankModel> criteriaRanks)
        {
            var criteria = await _criteriaRepository.GetCriteriaByIdAsync(criteriaRanks[0].CriteriaId);
            var project = criteria.Project;
            project.Status = 3;
            project.DateUpdated = DateTime.Now;

            foreach (var cr in criteriaRanks)
            {
                cr.DateCreated = DateTime.Now;
                cr.DateUpdated = DateTime.Now;
                cr.CriteriaRankId = Guid.NewGuid();                
            }

            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _criteriaRankRepository.AddRange(criteriaRanks);
                await _projectRepository.UpdateProject(project);
                uow.Commit();
            }

            return true;
        }


    }
}
