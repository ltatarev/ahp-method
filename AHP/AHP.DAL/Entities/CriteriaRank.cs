using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class CriteriaRank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CriteriaRankId { get; set; }

        public int Column { get; set; }

        public double Priority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int CriteriaId { get; set; }
        public Criteria Criteria { get; set; }
    }
}
