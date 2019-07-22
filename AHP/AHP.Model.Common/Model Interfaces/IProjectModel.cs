using System;

namespace AHP.Model.Common.Model_Interfaces
{
    class IProjectModel
    {

        int ProjectId { get; set; }
        string Username { get; set; }
        string ProjectName { get; set; }
        string Description { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

    }
}
