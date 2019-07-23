using System;
using System.Collections.Generic;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface ICriteriaModel
    {

        int CriteriaId { get; set; }
        int Order { get; set; }
        string CriteriaName { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        // second part not sure for IProjectModel

        int ProjectId { get; set; }
        IProjectModel Project { get; set; }
        ICollection<IAlternativeRankModel> AlternativeRanks { get; set; }
        ICollection<ICriteriaRankModel> CriteriaRanks { get; set; }

    }
}
