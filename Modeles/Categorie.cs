using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Categorie
    {
        public int CategorieID { get; set; }
        [Required(ErrorMessage = "Veuillez donner un libellé")]
        public string Libelle { get; set; }

        public ICollection<Livre> Livres { get; set; }
    }
}
