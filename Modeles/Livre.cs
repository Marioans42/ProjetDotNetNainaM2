using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class Livre
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public String dapparution { get; set; }
        public Auteur auteur { get; set; }
        public Categorie categorie { get; set; }
    }
}
