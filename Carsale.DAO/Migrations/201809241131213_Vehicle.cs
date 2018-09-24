namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehicle : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sales", name: "Vehicle_Matriculation", newName: "VehicleMatriculation");
            RenameIndex(table: "dbo.Sales", name: "IX_Vehicle_Matriculation", newName: "IX_VehicleMatriculation");
            DropColumn("dbo.Sales", "VehicleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "VehicleId", c => c.String());
            RenameIndex(table: "dbo.Sales", name: "IX_VehicleMatriculation", newName: "IX_Vehicle_Matriculation");
            RenameColumn(table: "dbo.Sales", name: "VehicleMatriculation", newName: "Vehicle_Matriculation");
        }
    }
}
