using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class AlternativeView
    {
        public int AlternativeId { get; set; }
        public int Order { get; set; }
        public string AlternativeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int FinalPriority { get; set; }

    }
}