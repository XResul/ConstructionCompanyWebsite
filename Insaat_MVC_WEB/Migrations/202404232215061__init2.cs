namespace Insaat_MVC_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MailSetting", "Port", c => c.Int(nullable: false));
            AlterColumn("dbo.MailSetting", "EnableSsl", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MailSetting", "EnableSsl", c => c.Boolean());
            AlterColumn("dbo.MailSetting", "Port", c => c.Int());
        }
    }
}
