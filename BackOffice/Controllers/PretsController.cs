using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modeles;
using Repositories;
using Services.Service;

namespace BackOffice.Controllers
{
    [Authorize]
    public class PretsController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private PretService pretService;

        public PretsController()
        {
            this.pretService = new PretService(this.context);
        }

        // GET: Prets
        public ActionResult Index()
        {
            return View(pretService.GetPrets());
        }

        // GET: Prets/Details/5
        public ActionResult Details(int id)
        {
            Pret pret = pretService.GetPretByID(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Prets/Create
        public ActionResult Create()
        {
            ViewBag.LivreID = new SelectList(context.Livres, "LivreID", "Titre");
            ViewBag.MembreID = new SelectList(context.Membres, "MembreID", "Nom");
            return View();
        }

        // POST: Prets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PretID,Ddebut,Dfin,Dretour,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                pretService.InsertPret(pret);
                pretService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.LivreID = new SelectList(context.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(context.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Prets/Edit/5
        public ActionResult Edit(int id)
        {
            Pret pret = pretService.GetPretByID(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivreID = new SelectList(context.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(context.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // POST: Prets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PretID,Ddebut,Dfin,Dretour,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                pretService.UpdatePret(pret);
                //pretService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.LivreID = new SelectList(context.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(context.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Prets/Delete/5
        public ActionResult Delete(int id)
        {
            Pret pret = pretService.GetPretByID(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Prets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pretService.DeletePret(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
