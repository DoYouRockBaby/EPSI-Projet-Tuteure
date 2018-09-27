namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        SIRET = c.String(maxLength: 14),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Reference = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        FuelWholesalerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Reference)
                .ForeignKey("dbo.FuelWholesalers", t => t.FuelWholesalerId, cascadeDelete: true)
                .Index(t => t.FuelWholesalerId);
            
            CreateTable(
                "dbo.FuelWholesalers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                        Mileage = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FuelReference = c.String(maxLength: 128),
                        VehicleMatriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fuels", t => t.FuelReference)
                .ForeignKey("dbo.Vehicles", t => t.VehicleMatriculation)
                .Index(t => t.FuelReference)
                .Index(t => t.VehicleMatriculation);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Matriculation = c.String(nullable: false, maxLength: 128),
                        Price = c.Double(nullable: false),
                        Mileage = c.Double(nullable: false),
                        BrandId = c.Int(nullable: false),
                        VehicleColor = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matriculation)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
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
            
            CreateTable(
                "dbo.MaintenanceBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        MaintenanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Maintenances", t => t.MaintenanceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.MaintenanceId);
            
            CreateTable(
                "dbo.Maintenances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkingTime = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        VehicleMatriculation = c.String(maxLength: 128),
                        HourlyRateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HourlyRates", t => t.HourlyRateId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleMatriculation)
                .Index(t => t.VehicleMatriculation)
                .Index(t => t.HourlyRateId);
            
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
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleMatriculation = c.String(maxLength: 128),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleMatriculation)
                .Index(t => t.VehicleMatriculation)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.TradeIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        MatriculationNew = c.String(),
                        MatriculationTradeIn = c.String(),
                        DateTradeIn = c.DateTime(nullable: false),
                        Mileage = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Vehicle_Matriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Matriculation)
                .Index(t => t.ClientId)
                .Index(t => t.Vehicle_Matriculation);
            
            CreateTable(
                "dbo.PartMaintenances",
                c => new
                    {
                        Part_Id = c.Int(nullable: false),
                        Maintenance_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Part_Id, t.Maintenance_Id })
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .ForeignKey("dbo.Maintenances", t => t.Maintenance_Id, cascadeDelete: true)
                .Index(t => t.Part_Id)
                .Index(t => t.Maintenance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TradeIns", "Vehicle_Matriculation", "dbo.Vehicles");
            DropForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Sales", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Sales", "ClientId", "dbo.Clients");
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
            DropIndex("dbo.TradeIns", new[] { "Vehicle_Matriculation" });
            DropIndex("dbo.TradeIns", new[] { "ClientId" });
            DropIndex("dbo.Sales", new[] { "ClientId" });
            DropIndex("dbo.Sales", new[] { "VehicleMatriculation" });
            DropIndex("dbo.Maintenances", new[] { "HourlyRateId" });
            DropIndex("dbo.Maintenances", new[] { "VehicleMatriculation" });
            DropIndex("dbo.MaintenanceBills", new[] { "MaintenanceId" });
            DropIndex("dbo.MaintenanceBills", new[] { "ClientId" });
            DropIndex("dbo.Vehicles", new[] { "BrandId" });
            DropIndex("dbo.FuelSales", new[] { "VehicleMatriculation" });
            DropIndex("dbo.FuelSales", new[] { "FuelReference" });
            DropIndex("dbo.Fuels", new[] { "FuelWholesalerId" });
            DropTable("dbo.PartMaintenances");
            DropTable("dbo.TradeIns");
            DropTable("dbo.Sales");
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
