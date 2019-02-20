using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class MembreRepository : IMembreRepository, IDisposable
    {
        private ProjetContext context;

        public MembreRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Membre> GetMembres()
        {
            return context.Membres.ToList();
        }

        public Membre GetMembreByID(int id)
        {
            return context.Membres.Find(id);
        }

        public void InsertMembre(Membre membre)
        {
            context.Membres.Add(membre);
        }

        public void DeleteMembre(int membreID)
        {
            Membre membre = context.Membres.Find(membreID);
            context.Membres.Remove(membre);
        }

        public void UpdateMembre(Membre membre)
        {
            context.Entry(membre).State = EntityState.Modified;
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
