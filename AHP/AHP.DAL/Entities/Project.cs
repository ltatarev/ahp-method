using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [StringLength(50), Required]
        public string Username { get; set; }
        [StringLength(50), Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public virtual ICollection<Criteria> Criterias { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; }
       
    }
}
