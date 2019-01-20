using Modeles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProjetContext : DbContext
    {
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Pret> Pret { get; set; }
    }
}
