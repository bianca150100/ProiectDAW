namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataAP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Pacient_PacientId", "dbo.Pacients");
            DropIndex("dbo.Appointments", new[] { "Pacient_PacientId" });
            AddColumn("dbo.Appointments", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Appointments", "Pacient_PacientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Pacient_PacientId", c => c.Int());
            DropColumn("dbo.Appointments", "Email");
            DropColumn("dbo.Appointments", "LastName");
            DropColumn("dbo.Appointments", "FirstName");
            CreateIndex("dbo.Appointments", "Pacient_PacientId");
            AddForeignKey("dbo.Appointments", "Pacient_PacientId", "dbo.Pacients", "PacientId");
        }
    }
}
