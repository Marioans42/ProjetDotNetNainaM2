using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Services;
using Services.Service;
using Modeles;
using FrontOffice.ViewModels;
using FrontOffice.Utils;

namespace FrontOffice.Controllers
{
    public class InscriptionController : Controller
    {
        ProjetContext db = new ProjetContext();

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
                    var membres = MembreService.FindAll(db).Where(u => u.Email.Equals(inscriptionVueModele.Membre.Email));

                    if (membres.Count() == 0)
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

                        MembreService.Add(membre, db);
                        db.SaveChanges();
                        return Redirect("/Login/Login");
                    }
                }
            }
            return View(inscriptionVueModele);
        }
    }
}