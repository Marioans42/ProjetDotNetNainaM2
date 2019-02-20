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
    public class PretService : PretRepository
    {
        public PretService(ProjetContext context) : base(context)
        {
            
        }

        public IEnumerable<Pret> GetPretByMembre(int membreID)
        {
            return this.GetPrets().Where(p => p.MembreID.Equals(membreID));
        }
    }
}
