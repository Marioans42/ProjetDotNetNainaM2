using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Membre
    {
        public int MembreID { get; set; }
        [Required(ErrorMessage = "Veuillez donner un nom.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Veuillez donner un prénom.")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Veuillez donner un email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Mdp { get; set; }

        [Required(ErrorMessage = "Veuillez donner une date de naissance")]
        [DataType(DataType.Date)]
        [Display(Name = "Date dde naissance")]
        public DateTime Dnaiss { get; set; }

        public virtual ICollection<Pret> Prets { get; set; }
    }
}