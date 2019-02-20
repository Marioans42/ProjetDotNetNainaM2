using BackOffice.ViewModels;
using BackOffice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Modeles;
using Repositories;
using Services.Service;

namespace BackOffice.Controllers
{
    public class InscriptionController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private UtilisateurService utilisateurService;

        public InscriptionController()
        {
            this.utilisateurService = new UtilisateurService(context);
        }

        // GET: Inscription/Inscription
        public ActionResult Inscription()
        {
            return View();
        }

        // POST: Inscription/Inscription
        [HttpPost]
        public ActionResult Inscription(InscriptionVueModele inscriptionVueModele)
        {
            if(!String.IsNullOrEmpty(inscriptionVueModele.Utilisateur.Mdp) && !String.IsNullOrEmpty(inscriptionVueModele.Mdp2))
            {
                if (inscriptionVueModele.Utilisateur.Mdp == inscriptionVueModele.Mdp2)
                {
                    if (utilisateurService.CheckForDuplicatedEmail(inscriptionVueModele.Utilisateur.Email))
                    {
                        string mdp = Hashage.Sha256(inscriptionVueModele.Utilisateur.Mdp);
                        var utilisateur = new Utilisateur()
                        {
                            Nom = inscriptionVueModele.Utilisateur.Nom,
                            Prenom = inscriptionVueModele.Utilisateur.Prenom,
                            Email = inscriptionVueModele.Utilisateur.Email,
                            Mdp = mdp
                        };

                        utilisateurService.InsertUtilisateur(utilisateur);
                        utilisateurService.Save();
                        return Redirect("/Login/Login");
                    }
                }
            }  
            return View(inscriptionVueModele);
        }
    }
}
