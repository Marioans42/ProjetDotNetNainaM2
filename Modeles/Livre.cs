using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class Livre
    {
        private int id { get; set; }
        private string titre { get; set; }
        private string description { get; set; }
        private DateTime dapparution { get; set; }
        private Auteur auteur { get; set; }
        private Categorie categorie { get; set; }
    }
}
