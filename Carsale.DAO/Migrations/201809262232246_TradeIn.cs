namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradeIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TradeIns", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.TradeIns", "MatriculationNew", c => c.String(maxLength: 128));
            AddColumn("dbo.TradeIns", "MatriculationTradeIn", c => c.String(maxLength: 128));
            AddColumn("dbo.TradeIns", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.TradeIns", "ClientId");
            AddForeignKey("dbo.TradeIns", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TradeIns", "MatriculationNew", "dbo.Vehicles", "Matriculation");
            AddForeignKey("dbo.TradeIns", "MatriculationTradeIn", "dbo.Vehicles", "Matriculation");
        }

        public override void Down()
        {
            
            
            DropColumn("dbo.TradeIns", "DateTradeIn");
            DropColumn("dbo.TradeIns", "MatriculationTradeIn");
            DropColumn("dbo.TradeIns", "MatriculationNew");
        }
    }
}
