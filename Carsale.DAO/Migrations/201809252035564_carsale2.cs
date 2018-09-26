namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carsale2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.HourlyRates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HourlyRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        MaintenanceType = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
