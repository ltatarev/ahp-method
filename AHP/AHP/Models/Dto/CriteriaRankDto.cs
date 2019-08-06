using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models.Dto
{
    public class CriteriaRankDto
    {
        public Guid CriteriaId { get; set; }
        public int Column { get; set; }
        public float Priority { get; set; }
    }
}