namespace MvcPossAppDatabseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesomethiss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Comments", c => c.Single(nullable: false));
        }
    }
}
