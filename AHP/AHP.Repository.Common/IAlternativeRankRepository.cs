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
    public interface IAlternativeRankRepository
    {
        Task<List<IAlternativeRankModel>> GetAlternativeRanks(int pageNumber, int pageSize);
        Task<IAlternativeRankModel> GetAlternativeRankByIdAsync(Guid alterRankId);
        Task<IAlternativeRankModel> InsertAlternativeRank(IAlternativeRankModel alterRank);
        Task<List<IAlternativeRankModel>> AddRange(List<IAlternativeRankModel> alternativeRanks);
        Task<bool> DeleteAlternativeRank(Guid alterRankId);
        Task<int> SaveAsync();
    }
}
