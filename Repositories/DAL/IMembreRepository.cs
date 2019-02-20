using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public interface IMembreRepository : IDisposable
    {
        IEnumerable<Membre> GetMembres();
        Membre GetMembreByID(int membreID);
        void InsertMembre(Membre membre);
        void DeleteMembre(int membreID);
        void UpdateMembre(Membre membre);
        void Save();
    }
}
