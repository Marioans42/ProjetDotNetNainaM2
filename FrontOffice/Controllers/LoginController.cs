using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Service;
using Modeles;
using System.Web.Security;
using FrontOffice.Utils;

namespace FrontOffice.Controllers
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
        public ActionResult Login(Membre membre, string ReturnUrl)
        {
            if (!String.IsNullOrEmpty(membre.Email) && !String.IsNullOrEmpty(membre.Mdp))
            {
                if (IsValid(membre))
                {
                    FormsAuthentication.SetAuthCookie(membre.Email, false);
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return Redirect("/Livres/Index");
                }
            }

            membre.Mdp = "";
            return View(membre);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private Boolean IsValid(Membre membre)
        {
            var mdp = Hashage.Sha256(membre.Mdp);
            var membres = MembreService.FindAll(db).Where(u => u.Email.Equals(membre.Email) && u.Mdp.Equals(mdp));
            return (membres.Count() == 1);
        }
    }
}