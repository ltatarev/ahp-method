using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common;

namespace AHP.Model.Models
{
    class AlternativeModel
    {

        public int AlternativeId { get; set; }
        public int Order { get; set; }
        public string AlternativeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int FinalPriority { get; set; }

    }
}
