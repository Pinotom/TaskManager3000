namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveVisiblePropertyInTask : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "Visible");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Visible", c => c.Boolean(nullable: false));
        }
    }
}
