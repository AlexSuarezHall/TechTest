namespace TechTest.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        ColourId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ColourId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        PreviouslyOrdered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.FavouriteColours",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.ColourId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.ColourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteColours", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.FavouriteColours", "PersonId", "dbo.People");
            DropIndex("dbo.FavouriteColours", new[] { "ColourId" });
            DropIndex("dbo.FavouriteColours", new[] { "PersonId" });
            DropTable("dbo.FavouriteColours");
            DropTable("dbo.People");
            DropTable("dbo.Colours");
        }
    }
}
