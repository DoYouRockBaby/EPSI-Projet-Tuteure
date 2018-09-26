namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maintenance : DbMigration
    {
        public override void Up()
        {
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
                "dbo.MaintenanceParts",
                c => new
                    {
                        Maintenance_Id = c.Int(nullable: false),
                        Part_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Maintenance_Id, t.Part_Id })
                .ForeignKey("dbo.Maintenances", t => t.Maintenance_Id, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .Index(t => t.Maintenance_Id)
                .Index(t => t.Part_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maintenances", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.MaintenanceParts", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.MaintenanceParts", "Maintenance_Id", "dbo.Maintenances");
            DropForeignKey("dbo.Maintenances", "HourlyRateId", "dbo.HourlyRates");
            DropIndex("dbo.MaintenanceParts", new[] { "Part_Id" });
            DropIndex("dbo.MaintenanceParts", new[] { "Maintenance_Id" });
            DropIndex("dbo.Maintenances", new[] { "HourlyRateId" });
            DropIndex("dbo.Maintenances", new[] { "VehicleMatriculation" });
            DropTable("dbo.MaintenanceParts");
            DropTable("dbo.Maintenances");
        }
    }
}
