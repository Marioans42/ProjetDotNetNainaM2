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
    public class CategoriesController : Controller
    {
        private CategorieService categorieService;

        public CategoriesController()
        {
            this.categorieService = new CategorieService(new ProjetContext());
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(categorieService.GetCategories());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Categorie categorie = categorieService.GetCategorieByID(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                categorieService.InsertCategorie(categorie);
                categorieService.Save();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Categorie categorie = categorieService.GetCategorieByID(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                categorieService.UpdateCategorie(categorie);
                //categorieService.Save();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Categorie categorie = categorieService.GetCategorieByID(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categorieService.DeleteCategorie(id);
            return RedirectToAction("Index");
        }
    }
}
