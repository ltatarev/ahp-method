using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models.Dto
{
    public class CriteriaAlternativeDto
    {
        public IList<CriterionDto> Criterias { get; set; }
        public IList<AlternativeDto> Alternatives { get; set; }
    }
}