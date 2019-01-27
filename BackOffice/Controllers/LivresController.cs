using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Modeles;
using Services;
using Services.Service;

namespace BackOffice.Controllers
{
    [Authorize]
    public class LivresController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Livres
        public ActionResult Index(string sortOrder, string rechercheString, int? page)
        {
            ViewBag.recherche = rechercheString;
            ViewBag.sortOrder = sortOrder;
            var livres = from s in LivreService.FindAll(db) select s;

            if(!String.IsNullOrEmpty(rechercheString))
            {
                livres = livres.Where(s => s.Titre.ToLower().Contains(rechercheString.ToLower()));
            }

            switch(sortOrder)
            {
                case "auteur":
                    livres = livres.OrderBy(s => s.Auteur.Nom);
                    break;

                case "categorie":
                    livres = livres.OrderBy(s => s.Categorie.Libelle);
                    break;

                case "date":
                    livres = livres.OrderBy(s => s.Dapparution);
                    break;

                default:
                    livres = livres.OrderBy(s => s.Titre);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(livres.ToPagedList(pageNumber, pageSize));
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = LivreService.Find(id, db);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            ViewBag.AuteurID = new SelectList(db.Auteurs, "AuteurID", "Nom");
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle");
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivreID,Titre,Description,Dapparution,AuteurID,CategorieID")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                LivreService.Add(livre, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuteurID = new SelectList(db.Auteurs, "AuteurID", "Nom", livre.AuteurID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", livre.CategorieID);
            return View(livre);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = LivreService.Find(id, db);
            if (livre == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuteurID = new SelectList(db.Auteurs, "AuteurID", "Nom", livre.AuteurID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", livre.CategorieID);
            return View(livre);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivreID,Titre,Description,Dapparution,AuteurID,CategorieID")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                LivreService.Update(livre, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuteurID = new SelectList(db.Auteurs, "AuteurID", "Nom", livre.AuteurID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", livre.CategorieID);
            return View(livre);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = LivreService.Find(id, db);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livre livre = LivreService.Find(id, db);
            LivreService.Remove(livre, db);
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
