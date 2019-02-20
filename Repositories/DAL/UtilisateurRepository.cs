using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class UtilisateurRepository : IUtilisateurRepository, IDisposable
    {
        private ProjetContext context;

        public UtilisateurRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            return context.Utilisateurs.ToList();
        }

        public Utilisateur GetUtilisateurByID(int id)
        {
            return context.Utilisateurs.Find(id);
        }

        public void InsertUtilisateur(Utilisateur utilisateur)
        {
            context.Utilisateurs.Add(utilisateur);
        }

        public void DeleteUtilisateur(int utilisateurID)
        {
            Utilisateur utilisateur = context.Utilisateurs.Find(utilisateurID);
            context.Utilisateurs.Remove(utilisateur);
        }

        public void UpdateUtilisateur(Utilisateur utilisateur)
        {
            context.Entry(utilisateur).State = EntityState.Modified;
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
