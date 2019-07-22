using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common;

namespace AHP.Model.Models
{
    class AlternativeRankModel
    {

        public int AlternativeRankId { get; set; }
        public int Alternative1 { get; set; }
        public int Alternative2 { get; set; }
        public float Preference { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
