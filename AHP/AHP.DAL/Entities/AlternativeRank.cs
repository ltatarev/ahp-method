using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class AlternativeRank
    {
        [Key]
        public Guid AlternativeRankId { get; set; }
        public int Alternative1 { get; set; }
        public int Alternative2 { get; set; }
        public double Preference { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Guid CriteriaId { get; set; }
        public Criteria Criteria { get; set; }
    }
}
