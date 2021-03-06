﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Model.Models
{
    public class AlternativeRankModel : IAlternativeRankModel
    {

        public Guid AlternativeRankId { get; set; }
        public int Alternative1 { get; set; }
        public int Alternative2 { get; set; }
        public float Preference { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Guid CriteriaId { get; set; }
        public ICriteriaModel Criteria { get; set; }

    }
}
