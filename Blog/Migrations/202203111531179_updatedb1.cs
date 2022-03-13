namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb1 : DbMigration
    {
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 225),
                        UrlSlug = c.String(maxLength: 225),
                        Description = c.String(maxLength: 1024),
                        Status = c.Boolean(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        ShortDescription = c.String(maxLength: 500),
                        PostContent = c.String(maxLength: 225),
                        UrlSlug = c.String(maxLength: 225),
                        Published = c.Boolean(),
                        PostedOn = c.DateTime(nullable: false),
                        Modifiled = c.DateTime(),
                        ViewCount = c.Int(),
                        RateCount = c.Int(),
                        TotalRate = c.Int(),
                        CategoryId = c.Int(),
                        Status = c.Byte(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 225),
                        Email = c.String(),
                        CommentHeader = c.String(),
                        CommentText = c.String(maxLength: 225),
                        CommentTime = c.DateTime(),
                        PostId = c.Int(),
                        Status = c.Byte(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength: 225),
                        UrlSlug = c.String(maxLength: 225),
                        Description = c.String(maxLength: 1024),
                        Count = c.Int(),
                        Status = c.Byte(),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50, unicode: false),
                        UserName = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostTagMap",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Up()
        {
            DropForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTagMap", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTagMap", new[] { "TagId" });
            DropIndex("dbo.PostTagMap", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.PostTagMap");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
