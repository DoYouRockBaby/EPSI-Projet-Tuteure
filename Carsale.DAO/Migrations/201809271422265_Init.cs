namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        ShowDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleMatriculation = c.String(maxLength: 128),
                        ClientId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Distance = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleMatriculation)
                .Index(t => t.VehicleMatriculation)
                .Index(t => t.ClientId);
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Sales", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Rents", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Rents", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.MaintenanceBills", "MaintenanceId", "dbo.Maintenances");
            DropForeignKey("dbo.Maintenances", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.PartMaintenances", "Maintenance_Id", "dbo.Maintenances");
            DropForeignKey("dbo.PartMaintenances", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.Maintenances", "HourlyRateId", "dbo.HourlyRates");
            DropForeignKey("dbo.MaintenanceBills", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.FuelSales", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.FuelSales", "FuelReference", "dbo.Fuels");
            DropForeignKey("dbo.Fuels", "FuelWholesalerId", "dbo.FuelWholesalers");
            DropIndex("dbo.PartMaintenances", new[] { "Maintenance_Id" });
            DropIndex("dbo.PartMaintenances", new[] { "Part_Id" });
            DropIndex("dbo.Sales", new[] { "ClientId" });
            DropIndex("dbo.Sales", new[] { "VehicleMatriculation" });
            DropIndex("dbo.Rents", new[] { "ClientId" });
            DropIndex("dbo.Rents", new[] { "VehicleMatriculation" });
            DropIndex("dbo.Maintenances", new[] { "HourlyRateId" });
            DropIndex("dbo.Maintenances", new[] { "VehicleMatriculation" });
            DropIndex("dbo.MaintenanceBills", new[] { "MaintenanceId" });
            DropIndex("dbo.MaintenanceBills", new[] { "ClientId" });
            DropIndex("dbo.Vehicles", new[] { "BrandId" });
            DropIndex("dbo.FuelSales", new[] { "VehicleMatriculation" });
            DropIndex("dbo.FuelSales", new[] { "FuelReference" });
            DropIndex("dbo.Fuels", new[] { "FuelWholesalerId" });
            DropTable("dbo.PartMaintenances");
            DropTable("dbo.Sales");
            DropTable("dbo.Rents");
            DropTable("dbo.Notifications");
            DropTable("dbo.Parts");
            DropTable("dbo.Maintenances");
            DropTable("dbo.MaintenanceBills");
            DropTable("dbo.HourlyRates");
            DropTable("dbo.Vehicles");
            DropTable("dbo.FuelSales");
            DropTable("dbo.FuelWholesalers");
            DropTable("dbo.Fuels");
            DropTable("dbo.Clients");
            DropTable("dbo.Brands");
            DropTable("dbo.Accounts");
        }
    }
}
