using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
    public interface ICriteriaRankRepository
    {
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting project
        //Example for checking if first criteriaRank was added

        Task<List<CriteriaRank>> GetCriteriaRanksAsync();
        Task<CriteriaRank> GetCriteriaRankByIdAsync(int CriteriaRankId);
        // void GetAlternativeRankByProjectId(int ProjectId);
        void InsertCriteriaRankAsync(CriteriaRank CriteriaRank);
        void DeleteCriteriaRankAsync(int CriteriaRankId);

        #endregion Methods
    }
}
