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
        public AlternativeService(IAlternativeRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this.Repository = repository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors
        #region Properties
        protected IAlternativeRepository Repository { get; private set; }
        protected IUnitOfWorkFactory uowFactory;
        #endregion Properties

        #region Methods

        public async Task<List<IAlternativeModel>> GetAlternativesByProjectId(Guid projectId, int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetAlternativesByProjectId(projectId, pageNumber,pageSize);
            return criterias;
        }
        public async Task<bool> AddRange(List<IAlternativeModel> alternatives)
        {

            var order = 1;
            foreach (var alter in alternatives)
            {
                alter.DateCreated = DateTime.Now;
                alter.DateUpdated = DateTime.Now;
                alter.Order = order;
                order++;
               // alter.ProjectId = id;
            }

            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await Repository.AddRange(alternatives);
                uow.Commit();
            }

            return true;
        }

        public async Task<IAlternativeModel> Update(IAlternativeModel alternative)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                var alternativeInDb = await Repository.GetAlternativeById(alternative.AlternativeId);
                alternativeInDb.DateUpdated = DateTime.Now;
                alternativeInDb.FinalPriority = alternative.FinalPriority;
                await Repository.UpdateAlternative(alternativeInDb);
                uow.Commit();
                return alternativeInDb;
            }
        }


        #endregion Methods
    }
}
