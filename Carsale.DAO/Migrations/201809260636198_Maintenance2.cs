namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maintenance2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MaintenanceParts", newName: "PartMaintenances");
            DropPrimaryKey("dbo.PartMaintenances");
            AddPrimaryKey("dbo.PartMaintenances", new[] { "Part_Id", "Maintenance_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PartMaintenances");
            AddPrimaryKey("dbo.PartMaintenances", new[] { "Maintenance_Id", "Part_Id" });
            RenameTable(name: "dbo.PartMaintenances", newName: "MaintenanceParts");
        }
    }
}
