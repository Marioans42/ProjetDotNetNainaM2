using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class CategorieService
    {
        public static void Add(Categorie categorie)
        {
            using (var context = new ProjetContext())
            {
                context.Categories.Add(categorie);
                context.SaveChanges();
            }
        }

        public static void Add(Categorie categorie, ProjetContext context)
        {
            context.Categories.Add(categorie);
        }

        public static void Update(Categorie categorie)
        {
            using (var context = new ProjetContext())
            {
                context.Categories.AddOrUpdate(categorie);
                context.SaveChanges();
            }
        }

        public static void Update(Categorie categorie, ProjetContext context)
        {
            context.Categories.AddOrUpdate(categorie);
        }

        public static void Remove(Categorie categorie)
        {
            using (var context = new ProjetContext())
            {
                context.Categories.Remove(categorie);
                context.SaveChanges();
            }
        }

        public static void Remove(Categorie categorie, ProjetContext context)
        {
            context.Categories.Remove(categorie);
        }

        public static Categorie Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var categorie = context.Categories.FirstOrDefault(a => a.CategorieID == id);
                return categorie;
            }
        }

        public static Categorie Find(int? id, ProjetContext context)
        {
            var categorie = context.Categories.FirstOrDefault(a => a.CategorieID == id);
            return categorie;
        }

        public static IEnumerable<Categorie> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Categories.ToList();
            }
        }

        public static IEnumerable<Categorie> FindAll(ProjetContext context)
        {
            return context.Categories.ToList();
        }
    }
}
