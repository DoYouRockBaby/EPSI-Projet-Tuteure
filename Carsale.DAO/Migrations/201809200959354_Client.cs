namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Client : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
