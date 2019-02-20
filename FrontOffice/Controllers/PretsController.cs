using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Modeles;
using Repositories;
using Services.Service;

namespace FrontOffice.Controllers
{
    public class PretsController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private PretService pretService;

        public PretsController()
        {
            this.pretService = new PretService(this.context);
        }

        // GET: Prets
        public ActionResult Index(string sortOrder, string titre, string debut, string fin, string retour, int? page)
        {
            var membreID = Convert.ToInt32(Session["userID"]);
            var prets = pretService.GetPretByMembre(membreID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(prets.ToPagedList(pageNumber, pageSize));
        }

        // POST: Prets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(string livreID)
        {
            var pret = new Pret();
            pret.LivreID = Convert.ToInt32(livreID);
            pret.MembreID = Convert.ToInt32(Session["userID"]);
            pret.Ddebut = DateTime.Today;
            pret.Dfin = pret.Ddebut.AddDays(8);

            pretService.InsertPret(pret);
            pretService.Save();
            return RedirectToAction("Index");
        }
    }
}