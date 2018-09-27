namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentSetUp2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.TradeIns", "Vehicle_Matriculation", "dbo.Vehicles");
            DropIndex("dbo.TradeIns", new[] { "ClientId" });
            DropIndex("dbo.TradeIns", new[] { "Vehicle_Matriculation" });
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
            
            DropColumn("dbo.Vehicles", "Mileage");
            DropTable("dbo.TradeIns");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "Mileage", c => c.Double(nullable: false));
            DropForeignKey("dbo.Rents", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Rents", "ClientId", "dbo.Clients");
            DropIndex("dbo.Rents", new[] { "ClientId" });
            DropIndex("dbo.Rents", new[] { "VehicleMatriculation" });
            DropTable("dbo.Rents");
            CreateIndex("dbo.TradeIns", "Vehicle_Matriculation");
            CreateIndex("dbo.TradeIns", "ClientId");
            AddForeignKey("dbo.TradeIns", "Vehicle_Matriculation", "dbo.Vehicles", "Matriculation");
            AddForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
