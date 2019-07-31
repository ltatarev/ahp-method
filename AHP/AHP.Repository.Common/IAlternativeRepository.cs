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
	public interface IAlternativeRepository
	{
        Task<List<IAlternativeModel>> GetAlternativesAsync(int pageNumber, int pageSize);
        Task<IAlternativeModel> GetAlternativeById(Guid alternativeId);
        Task<List<IAlternativeModel>> GetAlternativesByProjectId(Guid ProjectId, int pageNumber, int pageSize = 10);
        Task<IAlternativeModel> InsertAlternative(IAlternativeModel alternative);
        Task<List<IAlternativeModel>> AddRange(List<IAlternativeModel> alternatives);
        Task<IAlternativeModel> UpdateAlternative(IAlternativeModel alternative);
        Task<bool> DeleteAlternative(Guid AlternativeId);
        Task<int> SaveAsync();
    }
}
