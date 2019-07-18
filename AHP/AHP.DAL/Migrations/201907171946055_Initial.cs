namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativeRanks",
                c => new
                    {
                        AlternativeRankId = c.Int(nullable: false, identity: true),
                        Alternative1 = c.Int(nullable: false),
                        Alternative2 = c.Int(nullable: false),
                        Preference = c.Single(nullable: false),
                        CriteriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativeRankId)
                .ForeignKey("dbo.Criteria", t => t.CriteriaId, cascadeDelete: true)
                .Index(t => t.CriteriaId);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        CriteriaId = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        CriteriaName = c.String(),
                        Priority = c.Single(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CriteriaId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Alternatives",
                c => new
                    {
                        AlternativeId = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        AlternativeName = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.CriteriaRanks",
                c => new
                    {
                        CriteriaRankId = c.Int(nullable: false, identity: true),
                        Criteria1 = c.Int(nullable: false),
                        Criteria2 = c.Int(nullable: false),
                        Priority = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CriteriaRankId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Projects", t => t.ResultId)
                .Index(t => t.ResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "ResultId", "dbo.Projects");
            DropForeignKey("dbo.Criteria", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Alternatives", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AlternativeRanks", "CriteriaId", "dbo.Criteria");
            DropIndex("dbo.Results", new[] { "ResultId" });
            DropIndex("dbo.Alternatives", new[] { "ProjectId" });
            DropIndex("dbo.Criteria", new[] { "ProjectId" });
            DropIndex("dbo.AlternativeRanks", new[] { "CriteriaId" });
            DropTable("dbo.Results");
            DropTable("dbo.CriteriaRanks");
            DropTable("dbo.Alternatives");
            DropTable("dbo.Projects");
            DropTable("dbo.Criteria");
            DropTable("dbo.AlternativeRanks");
        }
    }
}
