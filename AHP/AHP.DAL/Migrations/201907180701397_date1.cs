namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "ResultId", "dbo.Projects");
            DropIndex("dbo.Results", new[] { "ResultId" });
            DropPrimaryKey("dbo.Results");
            AddColumn("dbo.AlternativeRanks", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.AlternativeRanks", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Criteria", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Criteria", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.CriteriaRanks", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.CriteriaRanks", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Results", "AlternativeId", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "PriorityId", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Results", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Results", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "ResultId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Results", "ResultId");
            CreateIndex("dbo.Results", "ProjectId");
            AddForeignKey("dbo.Results", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Results", new[] { "ProjectId" });
            DropPrimaryKey("dbo.Results");
            AlterColumn("dbo.Results", "ResultId", c => c.Int(nullable: false));
            DropColumn("dbo.Results", "ProjectId");
            DropColumn("dbo.Results", "DateUpdated");
            DropColumn("dbo.Results", "DateCreated");
            DropColumn("dbo.Results", "PriorityId");
            DropColumn("dbo.Results", "AlternativeId");
            DropColumn("dbo.CriteriaRanks", "DateUpdated");
            DropColumn("dbo.CriteriaRanks", "DateCreated");
            DropColumn("dbo.Projects", "DateUpdated");
            DropColumn("dbo.Projects", "DateCreated");
            DropColumn("dbo.Criteria", "DateUpdated");
            DropColumn("dbo.Criteria", "DateCreated");
            DropColumn("dbo.AlternativeRanks", "DateUpdated");
            DropColumn("dbo.AlternativeRanks", "DateCreated");
            AddPrimaryKey("dbo.Results", "ResultId");
            CreateIndex("dbo.Results", "ResultId");
            AddForeignKey("dbo.Results", "ResultId", "dbo.Projects", "ProjectId");
        }
    }
}
