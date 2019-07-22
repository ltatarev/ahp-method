﻿using System;
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

        IEnumerable<CriteriaRank> GetCriteriaRanks();
        CriteriaRank GetCriteriaRankById(int CriteriaRankId);
        // void GetAlternativeRankByProjectId(int ProjectId);
        void InsertCriteriaRank(CriteriaRank CriteriaRank);
        void DeleteCriteriaRank(int CriteriaRankId);

        #endregion Methods
    }
}