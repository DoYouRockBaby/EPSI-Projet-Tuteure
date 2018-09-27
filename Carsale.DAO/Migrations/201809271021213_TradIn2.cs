namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradIn2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Rents", "VehicleMatriculation", "dbo.Vehicles");
            DropIndex("dbo.Rents", new[] { "VehicleMatriculation" });
            DropIndex("dbo.Rents", new[] { "ClientId" });
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
            
            AddColumn("dbo.Vehicles", "Mileage", c => c.Double(nullable: false));
            DropTable("dbo.Rents");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TradeIns", "Vehicle_Matriculation", "dbo.Vehicles");
            DropForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients");
            DropIndex("dbo.TradeIns", new[] { "Vehicle_Matriculation" });
            DropIndex("dbo.TradeIns", new[] { "ClientId" });
            DropColumn("dbo.Vehicles", "Mileage");
            DropTable("dbo.TradeIns");
            CreateIndex("dbo.Rents", "ClientId");
            CreateIndex("dbo.Rents", "VehicleMatriculation");
            AddForeignKey("dbo.Rents", "VehicleMatriculation", "dbo.Vehicles", "Matriculation");
            AddForeignKey("dbo.Rents", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
