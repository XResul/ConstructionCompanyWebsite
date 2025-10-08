namespace InsaatEntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _initialM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        ContactTitle = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 40),
                        Whatsapp = c.String(maxLength: 40),
                        Email = c.String(maxLength: 120),
                        Adres = c.String(),
                        Map = c.String(),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.Langs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
  
            
            CreateTable(
                "dbo.pdfFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryID = c.Int(nullable: false, identity: true),
                        ProjectCategoryName = c.String(maxLength: 225),
                        ImageURL = c.String(maxLength: 250),
                        MetaDescription = c.String(),
                        MetaKey = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCategoryID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(maxLength: 255),
                        ThumbURL = c.String(maxLength: 255),
                        MetaDescription = c.String(),
                        MetaKey = c.String(maxLength: 255),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ProjectCategoryID = c.Int(nullable: false),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryID, cascadeDelete: true)
                .Index(t => t.ProjectCategoryID)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.ProjectImages",
                c => new
                    {
                        ProjectImageID = c.Int(nullable: false, identity: true),
                        ProjectImageURL = c.String(maxLength: 255),
                        ProjectThumbURL = c.String(maxLength: 255),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectImageID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        SliderTitle = c.String(maxLength: 120),
                        MetaDescription = c.String(maxLength: 255),
                        ImageURL = c.String(maxLength: 255),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SliderID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        SocialID = c.Int(nullable: false, identity: true),
                        Youtube = c.String(maxLength: 250),
                        Instagram = c.String(maxLength: 250),
                        Linkedin = c.String(maxLength: 250),
                        Facebook = c.String(maxLength: 250),
                        Twitter = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.SocialID);
            
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentTitle = c.String(maxLength: 125),
                        MetaDescription = c.String(maxLength: 500),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialsID = c.Int(nullable: false, identity: true),
                        TestimonialName = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 500),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialsID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 70),
                        UserPassword = c.String(maxLength: 70),
                        Email = c.String(maxLength: 90),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.VideoURLs",
                c => new
                    {
                        VideoUrlID = c.Int(nullable: false, identity: true),
                        videoUrlTitle = c.String(maxLength: 120),
                        VideoURL_ = c.String(),
                        LangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoUrlID)
                .ForeignKey("dbo.Langs", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoURLs", "LangId", "dbo.Langs");
            DropForeignKey("dbo.Testimonials", "LangId", "dbo.Langs");
            DropForeignKey("dbo.Talents", "LangId", "dbo.Langs");
            DropForeignKey("dbo.Sliders", "LangId", "dbo.Langs");
            DropForeignKey("dbo.ProjectImages", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectCategoryID", "dbo.ProjectCategories");
            DropForeignKey("dbo.Projects", "LangId", "dbo.Langs");
            DropForeignKey("dbo.ProjectCategories", "LangId", "dbo.Langs");
            DropForeignKey("dbo.pdfFiles", "LangId", "dbo.Langs");
            DropForeignKey("dbo.PageImages", "PageID", "dbo.Pages");
            DropForeignKey("dbo.Pages", "PageCategoryID", "dbo.PageCategories");
            DropForeignKey("dbo.Pages", "LangId", "dbo.Langs");
            DropForeignKey("dbo.PageCategories", "LangId", "dbo.Langs");
            DropForeignKey("dbo.Contacts", "LangId", "dbo.Langs");
            DropIndex("dbo.VideoURLs", new[] { "LangId" });
            DropIndex("dbo.Testimonials", new[] { "LangId" });
            DropIndex("dbo.Talents", new[] { "LangId" });
            DropIndex("dbo.Sliders", new[] { "LangId" });
            DropIndex("dbo.ProjectImages", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "LangId" });
            DropIndex("dbo.Projects", new[] { "ProjectCategoryID" });
            DropIndex("dbo.ProjectCategories", new[] { "LangId" });
            DropIndex("dbo.pdfFiles", new[] { "LangId" });
            DropIndex("dbo.PageImages", new[] { "PageID" });
            DropIndex("dbo.Pages", new[] { "LangId" });
            DropIndex("dbo.Pages", new[] { "PageCategoryID" });
            DropIndex("dbo.PageCategories", new[] { "LangId" });
            DropIndex("dbo.Contacts", new[] { "LangId" });
            DropTable("dbo.VideoURLs");
            DropTable("dbo.Users");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Talents");
            DropTable("dbo.Socials");
            DropTable("dbo.Sliders");
            DropTable("dbo.ProjectImages");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.pdfFiles");
            DropTable("dbo.PageImages");
            DropTable("dbo.Pages");
            DropTable("dbo.PageCategories");
            DropTable("dbo.Langs");
            DropTable("dbo.Contacts");
        }
    }
}
