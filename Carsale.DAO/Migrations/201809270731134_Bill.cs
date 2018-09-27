namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaintenanceBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        MaintenanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Maintenances", t => t.MaintenanceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.MaintenanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaintenanceBills", "MaintenanceId", "dbo.Maintenances");
            DropForeignKey("dbo.MaintenanceBills", "ClientId", "dbo.Clients");
            DropIndex("dbo.MaintenanceBills", new[] { "MaintenanceId" });
            DropIndex("dbo.MaintenanceBills", new[] { "ClientId" });
            DropTable("dbo.MaintenanceBills");
        }
    }
}
