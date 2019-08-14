using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class CriteriaAlternativeView
    {
        public IList<CriterionView> Criterias { get; set; }

        public IList<AlternativeView> Alternatives { get; set; }


    }
}