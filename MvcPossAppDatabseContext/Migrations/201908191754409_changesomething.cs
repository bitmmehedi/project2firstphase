namespace MvcPossAppDatabseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesomething : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Comments", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Comments");
        }
    }
}
