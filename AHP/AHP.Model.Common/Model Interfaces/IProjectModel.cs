using System;
using System.Collections.Generic;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface IProjectModel
    {

        Guid ProjectId { get; set; }
        string Username { get; set; }
        string ProjectName { get; set; }
        string Description { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        IList<ICriteriaModel> Criterias { get; set; }
        IList<IAlternativeModel> Alternatives { get; set; }

    }
}
