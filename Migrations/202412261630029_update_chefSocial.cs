namespace Yummy_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_chefSocial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChefSocials", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChefSocials", "Url");
        }
    }
}
