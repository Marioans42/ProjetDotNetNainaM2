using Modeles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjetContext : DbContext
    {
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Pret> Prets { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ProjetContext>(new DropCreateDatabaseIfModelChanges<ProjetContext>());
            Database.SetInitializer<ProjetContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
