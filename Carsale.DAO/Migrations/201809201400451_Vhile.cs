namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vhile : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vehicles", name: "Brand_Id", newName: "BrandId");
            RenameIndex(table: "dbo.Vehicles", name: "IX_Brand_Id", newName: "IX_BrandId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vehicles", name: "IX_BrandId", newName: "IX_Brand_Id");
            RenameColumn(table: "dbo.Vehicles", name: "BrandId", newName: "Brand_Id");
        }
    }
}
