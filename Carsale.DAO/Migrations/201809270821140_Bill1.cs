namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bill1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaintenanceBills", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaintenanceBills", "Date");
        }
    }
}
