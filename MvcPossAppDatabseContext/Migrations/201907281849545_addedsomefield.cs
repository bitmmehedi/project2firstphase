namespace MvcPossAppDatabseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomefield : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerModels");
        }
    }
}
