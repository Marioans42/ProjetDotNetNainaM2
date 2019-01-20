using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Modeles
{
    public class Membre
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string pseudo { get; set; }
        public string mdp { get; set; }
        public DateTime dnaiss { get; set; }
    }
}