namespace ProiectDAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pacients", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
