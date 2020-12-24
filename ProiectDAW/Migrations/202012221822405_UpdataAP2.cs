namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataAP2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Data", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Data", c => c.DateTime(nullable: false));
        }
    }
}
