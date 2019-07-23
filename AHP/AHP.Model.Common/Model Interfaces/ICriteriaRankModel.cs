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

        int Criteria1Id { get; set; }
        ICriteriaRankModel Criteria { get; set; }

    }
}
