using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Model.Models
{
    class CriteriaRankModel : ICriteriaRankModel
    {

        public int CriteriaRankId { get; set; }
        public int Column { get; set; }
        public float Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int Criteria1Id { get; set; }

    }
}
