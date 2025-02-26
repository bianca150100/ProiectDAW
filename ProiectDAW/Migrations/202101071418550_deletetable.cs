namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Pacients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        PacientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PacientId);
            
        }
    }
}
