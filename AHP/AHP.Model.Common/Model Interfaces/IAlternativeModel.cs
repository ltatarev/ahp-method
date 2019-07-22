using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.Model.Common.Model_Interfaces
{
    class IAlternativeModel
    {

        int AlternativeId { get; set; }
        int Order { get; set; }
        string AlternativeName { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        int FinalPriority { get; set; }

    }
}
