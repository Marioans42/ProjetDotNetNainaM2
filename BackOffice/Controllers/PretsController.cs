using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modeles;
using Services;
using Services.Service;

namespace BackOffice.Controllers
{
    [Authorize]
    public class PretsController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Prets
        public ActionResult Index()
        {
            return View(PretService.FindAll(db));
        }

        // GET: Prets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = PretService.Find(id, db);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Prets/Create
        public ActionResult Create()
        {
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre");
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom");
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
                PretService.Add(pret, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Prets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = PretService.Find(id, db);
            if (pret == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
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
                PretService.Update(pret, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Prets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = PretService.Find(id, db);
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
            Pret pret = PretService.Find(id, db);
            PretService.Remove(pret);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
