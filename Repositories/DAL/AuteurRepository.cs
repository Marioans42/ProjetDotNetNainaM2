using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class AuteurRepository : IAuteurRepository, IDisposable
    {
        private ProjetContext context;

        public AuteurRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Auteur> GetAuteurs()
        {
            return context.Auteurs.ToList();
        }

        public Auteur GetAuteurByID(int id)
        {
            return context.Auteurs.Find(id);
        }

        public void InsertAuteur(Auteur auteur)
        {
            context.Auteurs.Add(auteur);
        }

        public void DeleteAuteur(int auteurID)
        {
            Auteur auteur = context.Auteurs.Find(auteurID);
            context.Auteurs.Remove(auteur);
        }

        public void UpdateAuteur(Auteur auteur)
        {
            context.Entry(auteur).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
