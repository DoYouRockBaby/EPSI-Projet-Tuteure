namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuel4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FuelSales", new[] { "Vehicle_Matriculation" });
            DropColumn("dbo.FuelSales", "VehicleMatriculation");
            RenameColumn(table: "dbo.FuelSales", name: "Vehicle_Matriculation", newName: "VehicleMatriculation");
            AlterColumn("dbo.FuelSales", "VehicleMatriculation", c => c.String(maxLength: 128));
            CreateIndex("dbo.FuelSales", "VehicleMatriculation");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FuelSales", new[] { "VehicleMatriculation" });
            AlterColumn("dbo.FuelSales", "VehicleMatriculation", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FuelSales", name: "VehicleMatriculation", newName: "Vehicle_Matriculation");
            AddColumn("dbo.FuelSales", "VehicleMatriculation", c => c.Int(nullable: false));
            CreateIndex("dbo.FuelSales", "Vehicle_Matriculation");
        }
    }
}
