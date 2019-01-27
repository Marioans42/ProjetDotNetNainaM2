using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class LivreService
    {
        public static void Add(Livre livre)
        {
            using (var context = new ProjetContext())
            {
                context.Livres.Add(livre);
                context.SaveChanges();
            }
        }

        public static void Add(Livre livre, ProjetContext context)
        {
            context.Livres.Add(livre);
        }

        public static void Update(Livre livre)
        {
            using (var context = new ProjetContext())
            {
                context.Livres.AddOrUpdate(livre);
                context.SaveChanges();
            }
        }

        public static void Update(Livre livre, ProjetContext context)
        {
            context.Livres.AddOrUpdate(livre);
        }

        public static void Remove(Livre livre)
        {
            using (var context = new ProjetContext())
            {
                context.Livres.Remove(livre);
                context.SaveChanges();
            }
        }

        public static void Remove(Livre livre, ProjetContext context)
        {
            context.Livres.Remove(livre);
        }

        public static Livre Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var livre = context.Livres.FirstOrDefault(a => a.LivreID == id);
                return livre;
            }
        }

        public static Livre Find(int? id, ProjetContext context)
        {
            var livre = context.Livres.FirstOrDefault(a => a.LivreID == id);
            return livre;
        }

        public static IEnumerable<Livre> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Livres.ToList();
            }
        }

        public static IEnumerable<Livre> FindAll(ProjetContext context)
        {
            return context.Livres.ToList();
        }
    }
}
