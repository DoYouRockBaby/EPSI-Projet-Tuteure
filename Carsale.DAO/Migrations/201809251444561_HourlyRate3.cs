namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HourlyRate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourlyRates", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HourlyRates", "DateTime");
        }
    }
}
