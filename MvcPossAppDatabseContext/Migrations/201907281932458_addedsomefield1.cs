namespace MvcPossAppDatabseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomefield1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "CustEmail", c => c.String());
            AlterColumn("dbo.CustomerModels", "CustAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "CustAddress", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "CustEmail", c => c.String(nullable: false));
        }
    }
}
