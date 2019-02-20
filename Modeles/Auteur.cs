using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Auteur
    {
        public int AuteurID { get; set; }
        [Required(ErrorMessage = "Veuillez donner un nom.")]
        public string Nom { get; set; }

        public Auteur() { }

        public virtual ICollection<Livre> Livres { get; set; }
    }
}
