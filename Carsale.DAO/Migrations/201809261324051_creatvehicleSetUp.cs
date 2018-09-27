namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatvehicleSetUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.TradeIns", "VehicleMatriculation", "dbo.Vehicles");
            DropIndex("dbo.TradeIns", new[] { "ClientId" });
            DropIndex("dbo.TradeIns", new[] { "VehicleMatriculation" });
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
                        VehicleMatriculation = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Mileage = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "Mileage", c => c.Double(nullable: false));
            CreateIndex("dbo.TradeIns", "VehicleMatriculation");
            CreateIndex("dbo.TradeIns", "ClientId");
            AddForeignKey("dbo.TradeIns", "VehicleMatriculation", "dbo.Vehicles", "Matriculation");
            AddForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
