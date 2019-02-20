using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Modeles;
using Repositories;
using Services.Service;
using FrontOffice.Utils;

namespace FrontOffice.Controllers
{
    public class LoginController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private MembreService membreService;

        public LoginController()
        {
            this.membreService = new MembreService(context);
        }

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
                membre.Mdp = Hashage.Sha256(membre.Mdp);
                if (membreService.IsValidLogin(membre))
                {
                    var mdp = Hashage.Sha256(membre.Mdp);
                    membre = membreService.GetMembres().Where(u => u.Email.Equals(membre.Email) && u.Mdp.Equals(membre.Mdp)).First();

                    var cookie = Hashage.Sha256(membre.Email);
                    FormsAuthentication.SetAuthCookie(cookie, false);

                    Session["userID"] = membre.MembreID;

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
    }
}