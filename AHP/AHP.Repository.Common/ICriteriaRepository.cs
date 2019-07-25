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
        Task<ICriteriaModel> GetCriteriaByIdAsync(int CriteriaId);
        Task<List<ICriteriaModel>> GetCriteriasByProjectId(int ProjectId, int PageNumber, int PageSize);
        ICriteriaModel InsertCriteria(ICriteriaModel criteria);
        List<ICriteriaModel> AddRange(List<ICriteriaModel> criteria);
        Task<bool> DeleteCriteriaAsync(int CriteriaID);
        Task<int> SaveAsync();

    }
}
