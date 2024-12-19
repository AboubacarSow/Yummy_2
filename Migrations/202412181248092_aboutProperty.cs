namespace Yummy_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "ImageUrl_1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "ImageUrl_1");
        }
    }
}
