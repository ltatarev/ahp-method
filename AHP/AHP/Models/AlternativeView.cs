using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class AlternativeView
    {
        public Guid AlternativeId { get; set; }
        public int Order { get; set; }
        public string AlternativeName { get; set; }
        public double FinalPriority { get; set; }
        public Guid ProjectId { get; set; }


    }
}