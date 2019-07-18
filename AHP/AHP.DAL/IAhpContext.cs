using AHP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL
{
    public interface IAhpContext
    {
         DbSet<Project> Projects { get; set; }
         DbSet<Alternative> Alternatives { get; set; }
         DbSet<Criteria> Criterias { get; set; }
         DbSet<CriteriaRank> CriteriaRanks { get; set; }
         DbSet<AlternativeRank> AlternativeRanks { get; set; }
    }
}
