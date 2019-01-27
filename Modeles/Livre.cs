using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Livre
    {
        public int LivreID { get; set; }
        [Required(ErrorMessage = "Veuillez donner un titre")]
        public string Titre { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Veuillez donner une date d'apparution")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'apparution")]
        public DateTime Dapparution { get; set; }

        public int AuteurID { get; set; }
        public virtual Auteur Auteur { get; set; }

        public int CategorieID { get; set; }
        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<Pret> Prets { get; set; }
    }
}
