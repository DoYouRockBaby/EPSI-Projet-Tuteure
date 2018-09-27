namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        ShowDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "VehicleMatriculation", "dbo.Vehicles");
            DropForeignKey("dbo.Rents", "ClientId", "dbo.Clients");
            DropIndex("dbo.Rents", new[] { "ClientId" });
            DropIndex("dbo.Rents", new[] { "VehicleMatriculation" });
            DropTable("dbo.Rents");
            DropTable("dbo.Notifications");
        }
    }
}
