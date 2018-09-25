namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Price");
        }
    }
}
