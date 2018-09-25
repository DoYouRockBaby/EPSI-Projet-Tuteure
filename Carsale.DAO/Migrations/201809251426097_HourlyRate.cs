namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HourlyRate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HourlyRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parts");
            DropTable("dbo.HourlyRates");
        }
    }
}
