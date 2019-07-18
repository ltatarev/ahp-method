
using AHP.DAL.Entities;
using System.Data.Entity;

namespace AHP.DAL
{
    public class AHPContext : DbContext, IAHPContext
    {
        public AHPContext() : base("Server=praksa.database.windows.net;" +
            "Database=AHPContextDb;" +
            "User ID=jakovsudar;" +
            "Password=Praksa123;" +
            "Trusted_Connection=False;" +
            "Encrypt=True;" +
            "PersistSecurityInfo=True")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<CriteriaRank> CriteriaRanks { get; set; }
        public DbSet<AlternativeRank> AlternativeRanks { get; set; }        
    }
}
