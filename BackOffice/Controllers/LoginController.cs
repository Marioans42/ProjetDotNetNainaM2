using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Modeles;
using Repositories;
using Services.Service;
using BackOffice.Utils;

namespace BackOffice.Controllers
{
    public class LoginController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private UtilisateurService utilisateurService;

        public LoginController()
        {
            this.utilisateurService = new UtilisateurService(context);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utilisateur utilisateur, string ReturnUrl)
        {
            if (!String.IsNullOrEmpty(utilisateur.Email) && !String.IsNullOrEmpty(utilisateur.Mdp))
            {
                utilisateur.Mdp = Hashage.Sha256(utilisateur.Mdp);
                if (utilisateurService.IsValidLogin(utilisateur))
                {
                    FormsAuthentication.SetAuthCookie(utilisateur.Email, false);
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return Redirect("/Livres/Index");
                }
            }

            utilisateur.Mdp = "";
            return View(utilisateur);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}