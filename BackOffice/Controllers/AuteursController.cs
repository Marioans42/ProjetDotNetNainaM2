using System;
using System.Collections.Generic;
using System.Data;
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
    public class AuteursController : Controller
    {
        private AuteurService auteurService;

        public AuteursController()
        {
            this.auteurService = new AuteurService(new ProjetContext());
        }

        // GET: Auteurs
        public ActionResult Index()
        {
            return View(auteurService.GetAuteurs());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int id)
        {
            Auteur auteur = auteurService.GetAuteurByID(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                auteurService.InsertAuteur(auteur);
                auteurService.Save();
                return RedirectToAction("Index");
            }

            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int id)
        {
            Auteur auteur = auteurService.GetAuteurByID(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                auteurService.UpdateAuteur(auteur);
                //auteurService.Save();
                return RedirectToAction("Index");
            }
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int id)
        {
            Auteur auteur = auteurService.GetAuteurByID(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auteurService.DeleteAuteur(id);
            return RedirectToAction("Index");
        }
    }
}
