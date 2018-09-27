namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuel3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FuelSales", name: "Fuel_Reference", newName: "FuelReference");
            RenameIndex(table: "dbo.FuelSales", name: "IX_Fuel_Reference", newName: "IX_FuelReference");
            AddColumn("dbo.FuelSales", "VehicleMatriculation", c => c.Int(nullable: false));
            DropColumn("dbo.FuelSales", "FuelId");
            DropColumn("dbo.FuelSales", "VehicleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelSales", "VehicleId", c => c.Int(nullable: false));
            AddColumn("dbo.FuelSales", "FuelId", c => c.Int(nullable: false));
            DropColumn("dbo.FuelSales", "VehicleMatriculation");
            RenameIndex(table: "dbo.FuelSales", name: "IX_FuelReference", newName: "IX_Fuel_Reference");
            RenameColumn(table: "dbo.FuelSales", name: "FuelReference", newName: "Fuel_Reference");
        }
    }
}
