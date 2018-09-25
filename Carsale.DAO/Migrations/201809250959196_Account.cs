namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Double(nullable: false));
        }
    }
}
