using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Modeles;
using FrontOffice.ViewModels;
using Repositories;
using Services.Service;
using FrontOffice.Utils;

namespace FrontOffice.Controllers
{
    public class InscriptionController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private MembreService membreService;

        public InscriptionController()
        {
            this.membreService = new MembreService(context);
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
            if (!String.IsNullOrEmpty(inscriptionVueModele.Membre.Mdp) && !String.IsNullOrEmpty(inscriptionVueModele.Mdp2))
            {
                if (inscriptionVueModele.Membre.Mdp == inscriptionVueModele.Mdp2)
                {
                    if (membreService.CheckForDuplicatedEmail(inscriptionVueModele.Membre.Email))
                    {
                        string mdp = Hashage.Sha256(inscriptionVueModele.Membre.Mdp);
                        var membre = new Membre()
                        {
                            Nom = inscriptionVueModele.Membre.Nom,
                            Prenom = inscriptionVueModele.Membre.Prenom,
                            Dnaiss = inscriptionVueModele.Membre.Dnaiss,
                            Email = inscriptionVueModele.Membre.Email,
                            Mdp = mdp
                        };

                        membreService.InsertMembre(membre);
                        membreService.Save();
                        return Redirect("/Login/Login");
                    }
                }
            }
            return View(inscriptionVueModele);
        }
    }
}