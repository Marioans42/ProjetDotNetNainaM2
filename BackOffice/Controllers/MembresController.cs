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
    public class MembresController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Membres
        public ActionResult Index()
        {
            return View(MembreService.FindAll(db));
        }

        // GET: Membres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = MembreService.Find(id, db);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // GET: Membres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembreID,Nom,Prenom,Pseudo,Mdp,Dnaiss")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                MembreService.Add(membre, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membre);
        }

        // GET: Membres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = MembreService.Find(id, db);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembreID,Nom,Prenom,Pseudo,Mdp,Dnaiss")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                MembreService.Update(membre, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membre);
        }

        // GET: Membres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = MembreService.Find(id, db);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membre membre = MembreService.Find(id, db);
            MembreService.Remove(membre, db);
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
