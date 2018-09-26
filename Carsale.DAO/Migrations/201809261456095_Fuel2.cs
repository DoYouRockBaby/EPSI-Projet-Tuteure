namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fuels", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fuels", "Type");
        }
    }
}
