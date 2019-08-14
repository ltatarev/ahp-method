using System;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface ICriteriaRankModel
    {

        Guid CriteriaRankId { get; set; }
        int Column { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        Guid CriteriaId { get; set; }
        ICriteriaModel Criteria { get; set; }

    }
}
