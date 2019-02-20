using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;
using Repositories;
using Repositories.DAL;

namespace Services.Service
{
    public class UtilisateurService : UtilisateurRepository
    {
        public UtilisateurService(ProjetContext context) : base(context)
        {
        
        }

        public Boolean CheckForDuplicatedEmail(string email)
        {
            var utilisateurs = this.GetUtilisateurs().Where(u => u.Email.Equals(email));
            return utilisateurs.Count() == 0;
        }

        public Boolean IsValidLogin(Utilisateur utilisateur)
        {
            var utilisateurs = this.GetUtilisateurs().Where(u => u.Email.Equals(utilisateur.Email) && u.Mdp.Equals(utilisateur.Mdp));
            return (utilisateurs.Count() == 1);
        }
    }
}
