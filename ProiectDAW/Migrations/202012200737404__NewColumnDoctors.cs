namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _NewColumnDoctors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Function", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Description");
            DropColumn("dbo.Doctors", "Function");
        }
    }
}
