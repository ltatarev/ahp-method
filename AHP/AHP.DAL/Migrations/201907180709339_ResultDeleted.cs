namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Results", new[] { "ProjectId" });
            AddColumn("dbo.Alternatives", "FinalPriority", c => c.Int(nullable: false));
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        AlternativeId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
            DropColumn("dbo.Alternatives", "FinalPriority");
            CreateIndex("dbo.Results", "ProjectId");
            AddForeignKey("dbo.Results", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
