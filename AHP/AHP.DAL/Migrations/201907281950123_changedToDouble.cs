namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AlternativeRanks", "Preference", c => c.Double(nullable: false));
            AlterColumn("dbo.Criteria", "Priority", c => c.Double(nullable: false));
            AlterColumn("dbo.CriteriaRanks", "Priority", c => c.Double(nullable: false));
            AlterColumn("dbo.Alternatives", "FinalPriority", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alternatives", "FinalPriority", c => c.Int(nullable: false));
            AlterColumn("dbo.CriteriaRanks", "Priority", c => c.Single(nullable: false));
            AlterColumn("dbo.Criteria", "Priority", c => c.Single(nullable: false));
            AlterColumn("dbo.AlternativeRanks", "Preference", c => c.Single(nullable: false));
        }
    }
}
