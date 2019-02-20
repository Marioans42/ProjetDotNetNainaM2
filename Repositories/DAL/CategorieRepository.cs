using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public class CategorieRepository : ICategorieRepository, IDisposable
    {
        private ProjetContext context;

        public CategorieRepository(ProjetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categorie> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Categorie GetCategorieByID(int id)
        {
            return context.Categories.Find(id);
        }

        public void InsertCategorie(Categorie categorie)
        {
            context.Categories.Add(categorie);
        }

        public void DeleteCategorie(int categorieID)
        {
            Categorie categorie = context.Categories.Find(categorieID);
            context.Categories.Remove(categorie);
        }

        public void UpdateCategorie(Categorie categorie)
        {
            context.Entry(categorie).State = EntityState.Modified;
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
