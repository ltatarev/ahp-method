using System;

namespace AHP.Model.Common.Model_Interfaces
{
    class ICriteriaModel
    {

        int CriteriaId { get; set; }
        int Order { get; set; }
        string CriteriaName { get; set; }
        float Priority { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

    }
}
