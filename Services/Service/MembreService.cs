using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class MembreService
    {
        public static void Add(Membre membre)
        {
            using (var context = new ProjetContext())
            {
                context.Membres.Add(membre);
                context.SaveChanges();
            }
        }

        public static void Add(Membre membre, ProjetContext context)
        {
            context.Membres.Add(membre);
        }

        public static void Update(Membre membre)
        {
            using (var context = new ProjetContext())
            {
                context.Membres.AddOrUpdate(membre);
                context.SaveChanges();
            }
        }

        public static void Update(Membre membre, ProjetContext context)
        {
            context.Membres.AddOrUpdate(membre);
        }

        public static void Remove(Membre membre)
        {
            using (var context = new ProjetContext())
            {
                context.Membres.Remove(membre);
                context.SaveChanges();
            }
        }

        public static void Remove(Membre membre, ProjetContext context)
        {
            context.Membres.Remove(membre);
        }

        public static Membre Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var membre = context.Membres.FirstOrDefault(a => a.MembreID == id);
                return membre;
            }
        }

        public static Membre Find(int? id, ProjetContext context)
        {
            var membre = context.Membres.FirstOrDefault(a => a.MembreID == id);
            return membre;
        }

        public static IEnumerable<Membre> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Membres.ToList();
            }
        }

        public static IEnumerable<Membre> FindAll(ProjetContext context)
        {
            return context.Membres.ToList();
        }
    }
}
