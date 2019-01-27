using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Modeles;

namespace BackOffice.ViewModels
{
    public class InscriptionVueModele
    {
        public Utilisateur Utilisateur { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
        [Display(Name = "Confirmer le mot de passe")]
        public string Mdp2 { get; set; }
    }
}