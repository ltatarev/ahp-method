using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Model.Models
{
    class AlternativeModel : IAlternativeModel
    {

        public int AlternativeId { get; set; }
        public int Order { get; set; }
        public string AlternativeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int FinalPriority { get; set; }

        public int ProjectId { get; set; }
        public IProjectModel Project { get; set; }

    }
}
