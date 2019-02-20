using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    interface ILivreRepository : IDisposable
    {
        IEnumerable<Livre> GetLivres();
        Livre GetLivreByID(int livreID);
        void InsertLivre(Livre livre);
        void DeleteLivre(int livreID);
        void UpdateLivre(Livre livre);
        void Save();
    }
}
