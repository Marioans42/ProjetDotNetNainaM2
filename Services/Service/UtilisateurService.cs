using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class UtilisateurService
    {
        public static void Add(Utilisateur utilisateur)
        {
            using (var context = new ProjetContext())
            {
                context.Utilisateurs.Add(utilisateur);
                context.SaveChanges();
            }
        }

        public static void Add(Utilisateur utilisateur, ProjetContext context)
        {
            context.Utilisateurs.Add(utilisateur);
        }

        public static void Update(Utilisateur utilisateur)
        {
            using (var context = new ProjetContext())
            {
                context.Utilisateurs.AddOrUpdate(utilisateur);
                context.SaveChanges();
            }
        }

        public static void Update(Utilisateur utilisateur, ProjetContext context)
        {
            context.Utilisateurs.AddOrUpdate(utilisateur);
        }

        public static void Remove(Utilisateur utilisateur)
        {
            using (var context = new ProjetContext())
            {
                context.Utilisateurs.Remove(utilisateur);
                context.SaveChanges();
            }
        }

        public static void Remove(Utilisateur utilisateur, ProjetContext context)
        {
            context.Utilisateurs.Remove(utilisateur);
        }

        public static Utilisateur Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var utilisateur = context.Utilisateurs.FirstOrDefault(a => a.UtilisateurID == id);
                return utilisateur;
            }
        }

        public static Utilisateur Find(int? id, ProjetContext context)
        {
            var utilisateur = context.Utilisateurs.FirstOrDefault(a => a.UtilisateurID == id);
            return utilisateur;
        }

        public static IEnumerable<Utilisateur> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Utilisateurs.ToList();
            }
        }

        public static IEnumerable<Utilisateur> FindAll(ProjetContext context)
        {
            return context.Utilisateurs.ToList();
        }
    }
}
