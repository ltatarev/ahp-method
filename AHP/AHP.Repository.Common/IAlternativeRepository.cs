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
        Task<IAlternativeModel> GetAlternativeById(int alternativeId);
        Task<List<IAlternativeModel>> GetAlternativesByProjectId(int ProjectId, int pageNumber, int pageSize = 10);
        IAlternativeModel InsertAlternative(IAlternativeModel alternative);
        List<IAlternativeModel> AddRange(List<IAlternativeModel> alternatives);
        Task<bool> DeleteAlternative(int AlternativeId);
        Task<int> SaveAsync();
    }
}
