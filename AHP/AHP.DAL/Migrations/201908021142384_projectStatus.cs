namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Status");
        }
    }
}
