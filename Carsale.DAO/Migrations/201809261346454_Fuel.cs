namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Reference = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
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
                        FuelId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Fuel_Reference = c.String(maxLength: 128),
                        Vehicle_Matriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fuels", t => t.Fuel_Reference)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Matriculation)
                .Index(t => t.Fuel_Reference)
                .Index(t => t.Vehicle_Matriculation);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelSales", "Vehicle_Matriculation", "dbo.Vehicles");
            DropForeignKey("dbo.FuelSales", "Fuel_Reference", "dbo.Fuels");
            DropForeignKey("dbo.Fuels", "FuelWholesalerId", "dbo.FuelWholesalers");
            DropIndex("dbo.FuelSales", new[] { "Vehicle_Matriculation" });
            DropIndex("dbo.FuelSales", new[] { "Fuel_Reference" });
            DropIndex("dbo.Fuels", new[] { "FuelWholesalerId" });
            DropTable("dbo.FuelSales");
            DropTable("dbo.FuelWholesalers");
            DropTable("dbo.Fuels");
        }
    }
}
