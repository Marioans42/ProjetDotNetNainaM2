namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationModeles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        libelle = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        description = c.String(),
                        dapparution = c.DateTime(nullable: false),
                        auteur_id = c.Int(),
                        categorie_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Auteurs", t => t.auteur_id)
                .ForeignKey("dbo.Categories", t => t.categorie_id)
                .Index(t => t.auteur_id)
                .Index(t => t.categorie_id);
            
            CreateTable(
                "dbo.Membres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                        pseudo = c.String(),
                        mdp = c.String(),
                        dnaiss = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ddebut = c.DateTime(nullable: false),
                        dfin = c.DateTime(nullable: false),
                        drendue = c.DateTime(nullable: false),
                        livre_id = c.Int(),
                        membre_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Livres", t => t.livre_id)
                .ForeignKey("dbo.Membres", t => t.membre_id)
                .Index(t => t.livre_id)
                .Index(t => t.membre_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prets", "membre_id", "dbo.Membres");
            DropForeignKey("dbo.Prets", "livre_id", "dbo.Livres");
            DropForeignKey("dbo.Livres", "categorie_id", "dbo.Categories");
            DropForeignKey("dbo.Livres", "auteur_id", "dbo.Auteurs");
            DropIndex("dbo.Prets", new[] { "membre_id" });
            DropIndex("dbo.Prets", new[] { "livre_id" });
            DropIndex("dbo.Livres", new[] { "categorie_id" });
            DropIndex("dbo.Livres", new[] { "auteur_id" });
            DropTable("dbo.Prets");
            DropTable("dbo.Membres");
            DropTable("dbo.Livres");
            DropTable("dbo.Categories");
            DropTable("dbo.Auteurs");
        }
    }
}
