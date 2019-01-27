using BackOffice.ViewModels;
using BackOffice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Services;
using Services.Service;
using Modeles;

namespace BackOffice.Controllers
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
            if(!String.IsNullOrEmpty(inscriptionVueModele.Utilisateur.Mdp) && !String.IsNullOrEmpty(inscriptionVueModele.Mdp2))
            {
                if (inscriptionVueModele.Utilisateur.Mdp == inscriptionVueModele.Mdp2)
                {
                    var utilisateurs = UtilisateurService.FindAll(db).Where(u => u.Email.Equals(inscriptionVueModele.Utilisateur.Email));

                    if (utilisateurs.Count() == 0)
                    {
                        string mdp = Hashage.Sha256(inscriptionVueModele.Utilisateur.Mdp);
                        var utilisateur = new Utilisateur()
                        {
                            Nom = inscriptionVueModele.Utilisateur.Nom,
                            Prenom = inscriptionVueModele.Utilisateur.Prenom,
                            Email = inscriptionVueModele.Utilisateur.Email,
                            Mdp = mdp
                        };

                        UtilisateurService.Add(utilisateur, db);
                        db.SaveChanges();
                        return Redirect("/Login/Login");
                    }
                }
            }  
            return View(inscriptionVueModele);
        }
    }
}
