using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Modeles
{
    public class Membre
    {
        private int id { get; set; }
        private string nom { get; set; }
        private string prenom { get; set; }
        private string pseudo { get; set; }
        private string mdp { get; set; }
        private DateTime dnaiss { get; set; }
    }
}