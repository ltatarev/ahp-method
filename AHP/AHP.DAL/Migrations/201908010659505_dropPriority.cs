namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropPriority : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Criteria", "Priority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Criteria", "Priority", c => c.Double(nullable: false));
        }
    }
}
