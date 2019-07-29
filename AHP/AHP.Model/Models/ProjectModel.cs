using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Model.Models
{
    public class ProjectModel : IProjectModel
    {

        public int ProjectId { get; set; }
        public string Username { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual IList<ICriteriaModel> Criterias { get; set; }
        public virtual IList<IAlternativeModel> Alternatives { get; set; }

    }
}
