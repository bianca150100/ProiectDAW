namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _NewTableGeneralServ : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Services", "GeneralServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "GeneralServiceId");
            AddForeignKey("dbo.Services", "GeneralServiceId", "dbo.GeneralServices", "GeneralServiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "GeneralServiceId", "dbo.GeneralServices");
            DropIndex("dbo.Services", new[] { "GeneralServiceId" });
            DropColumn("dbo.Services", "GeneralServiceId");
            DropTable("dbo.GeneralServices");
        }
    }
}
