using System;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface ICriteriaRankModel
    {

        int CriteriaRankId { get; set; }
        int Column { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        int CriteriaId { get; set; }
        ICriteriaModel Criteria { get; set; }

    }
}
