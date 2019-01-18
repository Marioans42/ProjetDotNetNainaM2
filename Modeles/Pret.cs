using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class Pret
    {
        public int id { get; set; }
        public Membre membre { get; set; }
        public Livre livre { get; set; }
        public DateTime ddebut { get; set; }
        public DateTime dfin { get; set; }
        public DateTime drendue { get; set; }

    }
}
