using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class CriterionView
    {
        public int CriteriaId { get; set; }
        public int Order { get; set; }
        public string CriteriaName { get; set; }
        public float Priority { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }

}