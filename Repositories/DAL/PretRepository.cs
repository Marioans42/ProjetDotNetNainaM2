using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class PretRepository : IPretRepository, IDisposable
    {
        private ProjetContext context;

        public PretRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pret> GetPrets()
        {
            return context.Prets.ToList();
        }

        public Pret GetPretByID(int id)
        {
            return context.Prets.Find(id);
        }

        public void InsertPret(Pret pret)
        {
            context.Prets.Add(pret);
        }

        public void DeletePret(int pretID)
        {
            Pret pret = context.Prets.Find(pretID);
            context.Prets.Remove(pret);
        }

        public void UpdatePret(Pret pret)
        {
            context.Entry(pret).State = EntityState.Modified;
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
