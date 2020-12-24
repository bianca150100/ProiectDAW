namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pacients", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Pacients", new[] { "Appointment_Id" });
            AddColumn("dbo.Appointments", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "Pacient_PacientId", c => c.Int());
            CreateIndex("dbo.Appointments", "Pacient_PacientId");
            AddForeignKey("dbo.Appointments", "Pacient_PacientId", "dbo.Pacients", "PacientId");
            DropColumn("dbo.Pacients", "Appointment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "Appointment_Id", c => c.Int());
            DropForeignKey("dbo.Appointments", "Pacient_PacientId", "dbo.Pacients");
            DropIndex("dbo.Appointments", new[] { "Pacient_PacientId" });
            DropColumn("dbo.Appointments", "Pacient_PacientId");
            DropColumn("dbo.Appointments", "LastName");
            DropColumn("dbo.Appointments", "FirstName");
            CreateIndex("dbo.Pacients", "Appointment_Id");
            AddForeignKey("dbo.Pacients", "Appointment_Id", "dbo.Appointments", "Id");
        }
    }
}
