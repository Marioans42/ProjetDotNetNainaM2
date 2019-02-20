using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class LivreRepository : ILivreRepository, IDisposable
    {
        private ProjetContext context;

        public LivreRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Livre> GetLivres()
        {
            return context.Livres.ToList();
        }

        public Livre GetLivreByID(int id)
        {
            return context.Livres.Find(id);
        }

        public void InsertLivre(Livre livre)
        {
            context.Livres.Add(livre);
        }

        public void DeleteLivre(int livreID)
        {
            Livre livre = context.Livres.Find(livreID);
            context.Livres.Remove(livre);
        }

        public void UpdateLivre(Livre livre)
        {
            context.Entry(livre).State = EntityState.Modified;
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
