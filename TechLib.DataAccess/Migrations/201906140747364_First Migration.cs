namespace TechLib.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 100),
                        LName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        AuthorId = c.Int(nullable: false),
                        ReaderId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId)
                .Index(t => t.AuthorId)
                .Index(t => t.ReaderId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 100),
                        LName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ReaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "ReaderId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Readers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
