using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    interface ICategorieRepository : IDisposable
    {
        IEnumerable<Categorie> GetCategories();
        Categorie GetCategorieByID(int categorieID);
        void InsertCategorie(Categorie categorie);
        void DeleteCategorie(int categorieID);
        void UpdateCategorie(Categorie categorie);
        void Save();
    }
}
