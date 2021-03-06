﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL.Entities
{
    public class Alternative
    {
        [Key]
        public Guid AlternativeId { get; set; }
        public int Order { get; set; }
        public string AlternativeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public double FinalPriority { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
