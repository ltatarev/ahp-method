namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alternatives", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Alternatives", "DateUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alternatives", "DateUpdated");
            DropColumn("dbo.Alternatives", "DateCreated");
        }
    }
}
