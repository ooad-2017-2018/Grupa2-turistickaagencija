namespace FarAwayWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisnik2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DRodjenja = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpisUBazu",
                c => new
                    {
                        UpisUBazuId = c.Int(nullable: false, identity: true),
                        KorisnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UpisUBazuId)
                .ForeignKey("dbo.Korisnik2", t => t.KorisnikId, cascadeDelete: true)
                .Index(t => t.KorisnikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpisUBazu", "KorisnikId", "dbo.Korisnik2");
            DropIndex("dbo.UpisUBazu", new[] { "KorisnikId" });
            DropTable("dbo.UpisUBazu");
            DropTable("dbo.Korisnik2");
        }
    }
}
