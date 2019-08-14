using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class CriterionView
    {
        public Guid CriteriaId { get; set; }
        public int Order { get; set; }
        public string CriteriaName { get; set; }
        public float Priority { get; set; }
        public Guid ProjectId { get; set; }
    }

}