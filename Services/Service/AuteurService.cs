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
    public class AuteurService : AuteurRepository
    {
        public AuteurService(ProjetContext context) : base(context)
        {
            
        }
    }
}
