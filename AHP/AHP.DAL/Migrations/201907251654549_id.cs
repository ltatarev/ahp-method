namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CriteriaRanks", "Criteria_CriteriaId", "dbo.Criteria");
            DropIndex("dbo.CriteriaRanks", new[] { "Criteria_CriteriaId" });
            RenameColumn(table: "dbo.CriteriaRanks", name: "Criteria_CriteriaId", newName: "CriteriaId");
            AlterColumn("dbo.CriteriaRanks", "CriteriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.CriteriaRanks", "CriteriaId");
            AddForeignKey("dbo.CriteriaRanks", "CriteriaId", "dbo.Criteria", "CriteriaId", cascadeDelete: true);
            DropColumn("dbo.CriteriaRanks", "Criteria1Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CriteriaRanks", "Criteria1Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.CriteriaRanks", "CriteriaId", "dbo.Criteria");
            DropIndex("dbo.CriteriaRanks", new[] { "CriteriaId" });
            AlterColumn("dbo.CriteriaRanks", "CriteriaId", c => c.Int());
            RenameColumn(table: "dbo.CriteriaRanks", name: "CriteriaId", newName: "Criteria_CriteriaId");
            CreateIndex("dbo.CriteriaRanks", "Criteria_CriteriaId");
            AddForeignKey("dbo.CriteriaRanks", "Criteria_CriteriaId", "dbo.Criteria", "CriteriaId");
        }
    }
}
