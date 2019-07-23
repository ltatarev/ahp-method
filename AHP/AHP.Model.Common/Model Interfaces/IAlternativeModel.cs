using System;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface IAlternativeModel
    {

        int AlternativeId { get; set; }
        int Order { get; set; }
        string AlternativeName { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        int FinalPriority { get; set; }

        int ProjectId { get; set; }

    }
}
