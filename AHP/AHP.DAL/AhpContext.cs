
using AHP.DAL.Entities;
using System.Data.Entity;
using System.Configuration;

namespace AHP.DAL
{
    public class AHPContext : DbContext, IAHPContext
    {
        public AHPContext()
            : base ("Name=AHPContextDb")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<CriteriaRank> CriteriaRanks { get; set; }
        public DbSet<AlternativeRank> AlternativeRanks { get; set; }        
    }
}
