namespace Insaat_MVC_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _nint3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MailSetting", "Smtp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MailSetting", "Smtp");
        }
    }
}
