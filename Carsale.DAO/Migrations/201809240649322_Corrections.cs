namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "VehicleId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Sales", "Vehicle_Matriculation", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sales", "ClientId");
            CreateIndex("dbo.Sales", "Vehicle_Matriculation");
            AddForeignKey("dbo.Sales", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "Vehicle_Matriculation", "dbo.Vehicles", "Matriculation");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Sales", "SalePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "SalePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Sales", "Vehicle_Matriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Sales", "ClientId", "dbo.Clients");
            DropIndex("dbo.Sales", new[] { "Vehicle_Matriculation" });
            DropIndex("dbo.Sales", new[] { "ClientId" });
            DropColumn("dbo.Sales", "Vehicle_Matriculation");
            DropColumn("dbo.Sales", "Price");
            DropColumn("dbo.Sales", "Date");
            DropColumn("dbo.Sales", "ClientId");
            DropColumn("dbo.Sales", "VehicleId");
        }
    }
}
