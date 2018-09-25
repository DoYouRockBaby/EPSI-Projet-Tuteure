namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HourlyRate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourlyRates", "MaintenanceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HourlyRates", "MaintenanceType");
        }
    }
}
