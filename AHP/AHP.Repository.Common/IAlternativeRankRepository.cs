using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;

namespace AHP.Repository.Common
{
    public interface IAlternativeRankRepository
    {
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting project
        //Example for checking if first alternativeRank was added

        IEnumerable<AlternativeRank> GetAlternativeRanks();
        AlternativeRank GetAlternativeRankById(int AlternativeRankId);
       // void GetAlternativeRankByProjectId(int ProjectId);
        void InsertAlternativeRank(AlternativeRank AlternativeRank);
        void DeleteAlternativeRank(int AlternativeRankId);

        #endregion Methods
    }
}
