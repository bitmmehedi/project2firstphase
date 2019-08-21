namespace MvcPossAppDatabseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialstate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustCode = c.Int(nullable: false),
                        CustName = c.String(nullable: false, maxLength: 50),
                        CustEmail = c.String(nullable: false),
                        CustAddress = c.String(nullable: false),
                        CustContact = c.Int(nullable: false),
                        CustLoyaltyPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerModelsId = c.Int(nullable: false),
                        CustomerPayment = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerModelsId, cascadeDelete: true)
                .Index(t => t.CustomerModelsId);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerModelsId", "dbo.CustomerModels");
            DropIndex("dbo.SalesDetails", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "CustomerModelsId" });
            DropTable("dbo.SalesDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.CustomerModels");
        }
    }
}
