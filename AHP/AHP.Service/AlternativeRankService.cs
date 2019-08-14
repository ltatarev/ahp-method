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
        public AlternativeRankService(ICriteriaRepository criteriaRepository, IAlternativeRankRepository alternativeRankService, IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this._alternativeRankRepository = alternativeRankService;
            this._projectRepository = projectRepository;
            this._criteriaRepository = criteriaRepository;
            this._uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties
        private IProjectRepository _projectRepository;
        private IAlternativeRankRepository _alternativeRankRepository;
        private IUnitOfWorkFactory _uowFactory;
        private ICriteriaRepository _criteriaRepository;
        #endregion Properties

        #region Methods

        public async Task<bool> AddRange(List<IAlternativeRankModel> alternativeRanks)
        {
            var criteria =await _criteriaRepository.GetCriteriaByIdAsync(alternativeRanks[0].CriteriaId);
            var project = criteria.Project;
            project.Status = 5;
            project.DateUpdated = DateTime.Now;
            foreach (var ar in alternativeRanks)
            {
                ar.DateCreated = DateTime.Now;
                ar.DateUpdated = DateTime.Now;
                ar.AlternativeRankId = Guid.NewGuid();
            }
            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _alternativeRankRepository.AddRange(alternativeRanks);
                await _projectRepository.UpdateProject(project);
                uow.Commit();
            }
            return true;
        }

        #endregion Methods

    }
}
