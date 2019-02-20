using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public interface IPretRepository : IDisposable
    {
        IEnumerable<Pret> GetPrets();
        Pret GetPretByID(int pretID);
        void InsertPret(Pret pret);
        void DeletePret(int pretID);
        void UpdatePret(Pret pret);
        void Save();
    }
}
