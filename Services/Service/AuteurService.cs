using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class AuteurService
    {
        public static void Add(Auteur auteur)
        {
            using (var context = new ProjetContext())
            {
                context.Auteurs.Add(auteur);
                context.SaveChanges();
            }
        }

        public static void Add(Auteur auteur, ProjetContext context)
        {
            context.Auteurs.Add(auteur);
        }

        public static void Update(Auteur auteur)
        {
            using (var context = new ProjetContext())
            {
                context.Auteurs.AddOrUpdate(auteur);
                context.SaveChanges();
            }
        }

        public static void Update(Auteur auteur, ProjetContext context)
        {
            context.Auteurs.AddOrUpdate(auteur);
        }

        public static void Remove(Auteur auteur)
        {
            using (var context = new ProjetContext())
            {
                context.Auteurs.Remove(auteur);
                context.SaveChanges();
            }
        }

        public static void Remove(Auteur auteur, ProjetContext context)
        {
            context.Auteurs.Remove(auteur);
        }

        public static Auteur Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var auteur = context.Auteurs.FirstOrDefault(a => a.AuteurID == id);
                return auteur;
            }
        }

        public static Auteur Find(int? id, ProjetContext context)
        {
            var auteur = context.Auteurs.FirstOrDefault(a => a.AuteurID == id);
            return auteur;
        }

        public static IEnumerable<Auteur> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Auteurs.ToList();
            }
        }

        public static IEnumerable<Auteur> FindAll(ProjetContext context)
        {
            return context.Auteurs.ToList();
        }
    }
}
