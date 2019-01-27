using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;

namespace Services.Service
{
    public class PretService
    {
        public static void Add(Pret pret)
        {
            using (var context = new ProjetContext())
            {
                context.Prets.Add(pret);
                context.SaveChanges();
            }
        }

        public static void Add(Pret pret, ProjetContext context)
        {
            context.Prets.Add(pret);
        }

        public static void Update(Pret pret)
        {
            using (var context = new ProjetContext())
            {
                context.Prets.AddOrUpdate(pret);
                context.SaveChanges();
            }
        }

        public static void Update(Pret pret, ProjetContext context)
        {
            context.Prets.AddOrUpdate(pret);
        }

        public static void Remove(Pret pret)
        {
            using (var context = new ProjetContext())
            {
                context.Prets.Remove(pret);
                context.SaveChanges();
            }
        }

        public static void Remove(Pret pret, ProjetContext context)
        {
            context.Prets.Remove(pret);
        }

        public static Pret Find(int? id)
        {
            using (var context = new ProjetContext())
            {
                var pret = context.Prets.FirstOrDefault(a => a.PretID == id);
                return pret;
            }
        }

        public static Pret Find(int? id, ProjetContext context)
        {
            var pret = context.Prets.FirstOrDefault(a => a.PretID == id);
            return pret;
        }

        public static IEnumerable<Pret> FindAll()
        {
            using (var context = new ProjetContext())
            {
                return context.Prets.ToList();
            }
        }

        public static IEnumerable<Pret> FindAll(ProjetContext context)
        {
            return context.Prets.ToList();
        }
    }
}
