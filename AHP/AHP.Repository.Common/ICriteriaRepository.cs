using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository.Common
{
	public interface ICriteriaRepository
	{
        
        Task<List<ICriteriaModel>> GetCriteriasAsync(int PageNumber, int PageSize = 10);
        Task<ICriteriaModel> GetCriteriaByIdAsync(Guid CriteriaId);
        Task<List<ICriteriaModel>> GetCriteriasByProjectId(Guid ProjectId, int PageNumber, int PageSize);
        Task<List<ICriteriaModel>> GetCriteriasByProjectIdWithCRaAR(Guid projectId);
        Task<ICriteriaModel> InsertCriteria(ICriteriaModel criteria);
        Task<List<ICriteriaModel>> AddRange(List<ICriteriaModel> criteria);
        Task<bool> DeleteCriteriaAsync(Guid CriteriaID);
        Task<int> SaveAsync();

    }
}
