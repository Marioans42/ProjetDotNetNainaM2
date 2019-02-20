using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles;

namespace Repositories.DAL
{
    public interface IUtilisateurRepository : IDisposable
    {
        IEnumerable<Utilisateur> GetUtilisateurs();
        Utilisateur GetUtilisateurByID(int utilisateurID);
        void InsertUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateur(int utilisateurID);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void Save();
    }
}
