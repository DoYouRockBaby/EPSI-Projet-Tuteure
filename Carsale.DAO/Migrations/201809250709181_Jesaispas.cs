namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jesaispas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Address2", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Address2", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
