using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class Criteria
    {
        [Key]
        public int CriteriaId { get; set; }
        public int Order { get; set; }
        public string CriteriaName { get; set; }
        public float Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public virtual ICollection<AlternativeRank> AlternativeRanks { get; set; }
        public virtual ICollection<CriteriaRank> CriteriaRanks{ get; set; }

    }
}
