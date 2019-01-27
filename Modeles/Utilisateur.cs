using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class Utilisateur
    {
        public int UtilisateurID { get; set; }

        [Required(ErrorMessage = "Veuillez donner un nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Veuillez donner un prénom")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Veuillez donner un email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez donner un mot de passe")]
        [Display(Name = "Mot de passe")]
        public string Mdp { get; set; }
    }
}
