namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Ora = c.String(nullable: false),
                        MedicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medics", t => t.MedicId, cascadeDelete: true)
                .Index(t => t.MedicId);
            
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        MedicId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Experience = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Function = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MedicId);
            
            CreateTable(
                "dbo.GeneralServices",
                c => new
                    {
                        GeneralServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RecoveryPeriod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Pret = c.String(nullable: false),
                        GeneralServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralServices", t => t.GeneralServiceId, cascadeDelete: true)
                .Index(t => t.GeneralServiceId);
            
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        PacientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Appointment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PacientId)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .Index(t => t.Appointment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pacients", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Services", "GeneralServiceId", "dbo.GeneralServices");
            DropForeignKey("dbo.Appointments", "MedicId", "dbo.Medics");
            DropIndex("dbo.Pacients", new[] { "Appointment_Id" });
            DropIndex("dbo.Services", new[] { "GeneralServiceId" });
            DropIndex("dbo.Appointments", new[] { "MedicId" });
            DropTable("dbo.Pacients");
            DropTable("dbo.Services");
            DropTable("dbo.GeneralServices");
            DropTable("dbo.Medics");
            DropTable("dbo.Appointments");
        }
    }
}
