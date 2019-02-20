using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Pret
    {
        public int PretID { get; set; }

        [Required(ErrorMessage = "Veuillez donner une date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date début")]
        public DateTime Ddebut { get; set; }

        [Required(ErrorMessage = "Veuillez donner une date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date fin")]
        public DateTime Dfin { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date retour")]
        public DateTime? Dretour { get; set; }

        [Display(Name = "Membre")]
        public int MembreID { get; set; }
        public virtual Membre Membre { get; set; }

        [Display(Name = "Livre")]
        public int LivreID { get; set; }
        public virtual Livre Livre { get; set; }
    }
}
