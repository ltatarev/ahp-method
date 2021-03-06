﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository.Common
{
    public interface ICriteriaRankRepository
    {
        Task<List<ICriteriaRankModel>> GetCriteriaRanks(int pageNumber, int pageSize);
        Task<ICriteriaRankModel> GetCriteriaRankById(Guid criteriaRankId);
        Task<ICriteriaRankModel> InsertCriteriaRank(ICriteriaRankModel criteriaRank);
        Task<List<ICriteriaRankModel>> AddRange(List<ICriteriaRankModel> criteriaRanks);
        Task<bool> DeleteCriteriaRank(Guid criterRankId);
        Task<int> SaveAsync();
    }
}
