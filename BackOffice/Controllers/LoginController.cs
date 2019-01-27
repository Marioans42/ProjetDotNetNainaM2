using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Modeles;
using System.Web.Security;
using Services.Service;
using BackOffice.Utils;

namespace BackOffice.Controllers
{
    public class LoginController : Controller
    {
        private ProjetContext db = new ProjetContext();

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
                if (IsValid(utilisateur))
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

        private Boolean IsValid(Utilisateur utilisateur)
        {
            var mdp = Hashage.Sha256(utilisateur.Mdp);
            var utilisateurs = UtilisateurService.FindAll(db).Where(u => u.Email.Equals(utilisateur.Email) && u.Mdp.Equals(mdp));
            return (utilisateurs.Count() == 1);
        }
    }
}