namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppealUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appeals", "FileName", c => c.String());
            AddColumn("dbo.Appeals", "FileData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appeals", "FileData");
            DropColumn("dbo.Appeals", "FileName");
        }


    }
}
