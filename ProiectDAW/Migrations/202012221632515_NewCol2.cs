namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCol2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "FirstName");
            DropColumn("dbo.Appointments", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "FirstName", c => c.String(nullable: false));
        }
    }
}
