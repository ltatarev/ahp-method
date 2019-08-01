using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository.Common
{
	public interface IAlternativeRepository
	{       
        Task<IAlternativeModel> GetAlternativeById(Guid alternativeId);
        Task<List<IAlternativeModel>> GetAlternativesByProjectId(Guid ProjectId, int pageNumber, int pageSize = 10);
        Task<IAlternativeModel> InsertAlternative(IAlternativeModel alternative);
        Task<List<IAlternativeModel>> AddRange(List<IAlternativeModel> alternatives);
        Task<IAlternativeModel> UpdateAlternative(IAlternativeModel alternative);
        Task<bool> DeleteAlternative(Guid AlternativeId);
        
    }
}
