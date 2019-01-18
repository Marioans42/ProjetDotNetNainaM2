using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class Pret
    {
        private int id { get; set; }
        private Membre membre { get; set; }
        private Livre livre { get; set; }
        private DateTime ddebut { get; set; }
        private DateTime dfin { get; set; }
        private DateTime drendue { get; set; }

    }
}
