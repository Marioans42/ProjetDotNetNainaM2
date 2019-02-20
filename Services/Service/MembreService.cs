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
    public class MembreService : MembreRepository
    {
        public MembreService(ProjetContext context) : base(context)
        {
        
        }

        public Boolean CheckForDuplicatedEmail(string email)
        {
            var membres = this.GetMembres().Where(u => u.Email.Equals(email));
            return membres.Count() == 0;
        }

        public Boolean IsValidLogin(Membre membre)
        {
            var membres = this.GetMembres().Where(u => u.Email.Equals(membre.Email) && u.Mdp.Equals(membre.Mdp));
            return (membres.Count() == 1);
        }
    }
}
