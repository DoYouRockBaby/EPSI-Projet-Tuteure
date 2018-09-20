namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehicle1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Matriculation = c.String(nullable: false, maxLength: 128),
                        VehicleColor = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 255),
                        Status = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matriculation)
                .ForeignKey("dbo.Brands", t => t.Brand_Id, cascadeDelete: true)
                .Index(t => t.Brand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Vehicles", new[] { "Brand_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Brands");
        }
    }
}
