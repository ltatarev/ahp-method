using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class CriteriaRank
    {
        [Key]
        public int CriteriaRankId { get; set; }
        public int Criteria1 { get; set; }
        public int Criteria2 { get; set; }
        public float Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
