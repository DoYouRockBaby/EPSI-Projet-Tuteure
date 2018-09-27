namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuel31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelSales", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuelSales", "Date");
        }
    }
}
