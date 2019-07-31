using System;
using System.Collections.Generic;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface ICriteriaModel
    {

        Guid CriteriaId { get; set; }
        int Order { get; set; }
        string CriteriaName { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        // second part not sure for IProjectModel

        Guid ProjectId { get; set; }
        IProjectModel Project { get; set; }
        IList<IAlternativeRankModel> AlternativeRanks { get; set; }
        IList<ICriteriaRankModel> CriteriaRanks { get; set; }

    }
}
