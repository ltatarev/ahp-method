using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Model.Models
{
    class CriteriaModel : ICriteriaModel
    {

        public int CriteriaId { get; set; }
        public int Order { get; set; }
        public string CriteriaName { get; set; }
        public float Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        // second part not sure for IProjectModel

        public int ProjectId { get; set; }
        public IProjectModel Project { get; set; }
        public virtual ICollection<IAlternativeRankModel> AlternativeRanks { get; set; }
        public virtual ICollection<ICriteriaRankModel> CriteriaRanks { get; set; }

    }
}
