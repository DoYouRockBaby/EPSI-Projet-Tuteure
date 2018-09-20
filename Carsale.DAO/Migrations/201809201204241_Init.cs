namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        SIRET = c.String(maxLength: 14),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(nullable: false, maxLength: 255),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        SalePrice = c.Int(nullable: false),
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
            DropTable("dbo.Sales");
            DropTable("dbo.Clients");
            DropTable("dbo.Brands");
            DropTable("dbo.Accounts");
        }
    }
}
