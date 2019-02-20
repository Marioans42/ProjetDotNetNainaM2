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
    public class MembresController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private MembreService membreService;

        public MembresController()
        {
            this.membreService = new MembreService(this.context);
        }

        // GET: Membres
        public ActionResult Index()
        {
            return View(membreService.GetMembres());
        }

        // GET: Membres/Details/5
        public ActionResult Details(int id)
        {
            Membre membre = membreService.GetMembreByID(id);
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
                membreService.InsertMembre(membre);
                membreService.Save();
                return RedirectToAction("Index");
            }

            return View(membre);
        }

        // GET: Membres/Edit/5
        public ActionResult Edit(int id)
        {
            Membre membre = membreService.GetMembreByID(id);
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
                membreService.UpdateMembre(membre);
                //membreService.Save();
                return RedirectToAction("Index");
            }
            return View(membre);
        }

        // GET: Membres/Delete/5
        public ActionResult Delete(int id)
        {
            Membre membre = membreService.GetMembreByID(id);
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
            membreService.DeleteMembre(id);
            return RedirectToAction("Index");
        }
    }
}
