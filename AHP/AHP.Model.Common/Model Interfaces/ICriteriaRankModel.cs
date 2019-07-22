using System;

namespace AHP.Model.Common.Model_Interfaces
{
    class ICriteriaRankModel
    {

        int CriteriaRankId { get; set; }
        int Column { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

    }
}
