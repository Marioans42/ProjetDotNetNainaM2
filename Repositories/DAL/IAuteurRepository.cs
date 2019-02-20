using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public interface IAuteurRepository : IDisposable
    {
        IEnumerable<Auteur> GetAuteurs();
        Auteur GetAuteurByID(int auteurID);
        void InsertAuteur(Auteur auteur);
        void DeleteAuteur(int auteurID);
        void UpdateAuteur(Auteur auteur);
        void Save();
    }
}
