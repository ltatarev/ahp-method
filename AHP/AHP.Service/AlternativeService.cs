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
    public class AlternativeService : IAlternativeService
    {
        #region Constructors
        public AlternativeService(IAlternativeRepository alternativeRepository, IProjectRepository projectRepository, IUnitOfWorkFactory uowFactory)
        {
            this._alternativeRepository = alternativeRepository;
            this._projectRepository = projectRepository;
            this._uowFactory = uowFactory;
        }
        #endregion Constructors
        #region Properties
        private IProjectRepository _projectRepository;
        private IAlternativeRepository _alternativeRepository;
        private IUnitOfWorkFactory _uowFactory;
        #endregion Properties

        #region Methods

        public async Task<List<IAlternativeModel>> GetAlternativesByProjectId(Guid projectId, int pageNumber, int pageSize = 10)
        {
            var alternatives = await _alternativeRepository.GetAlternativesByProjectId(projectId, pageNumber,pageSize);
            return alternatives;
        }

        public async Task<bool> AddRange(List<IAlternativeModel> alternatives)
        {
            var project =await _projectRepository.GetProjectByIdAsync(alternatives[0].ProjectId);
            project.Status = 4;
            project.DateUpdated = DateTime.Now;
            var order = 1;
            foreach (var alter in alternatives)
            {
                alter.DateCreated = DateTime.Now;
                alter.DateUpdated = DateTime.Now;
                alter.Order = order;
                order++;
                alter.AlternativeId = Guid.NewGuid();
            }

            using (var uow = _uowFactory.CreateUnitOfWork())
            {
                await _projectRepository.UpdateProject(project);
                await _alternativeRepository.AddRange(alternatives);
                uow.Commit();
            }

            return true;
        }

        public async Task<IAlternativeModel> Update(IAlternativeModel alternative)
        {
            var alternativeInDb = await _alternativeRepository.GetAlternativeById(alternative.AlternativeId);
            alternativeInDb.DateUpdated = DateTime.Now;
            alternativeInDb.FinalPriority = alternative.FinalPriority;

            using (var uow = _uowFactory.CreateUnitOfWork())
            {                            
                await _alternativeRepository.UpdateAlternative(alternativeInDb);
                uow.Commit();                
            }
            return alternativeInDb;
        }


        #endregion Methods
    }
}
