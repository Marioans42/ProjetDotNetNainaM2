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
    [Authorize]
    public class LivresController : Controller
    {
        private ProjetContext context = new ProjetContext();
        private LivreService livreService;

        public LivresController()
        {
            this.livreService = new LivreService(this.context);
        }

        // GET: Livres
        public ActionResult Index(string sortOrder, string titre, string auteur, string categorie, int? page)
        {
            ViewBag.titre = titre;
            ViewBag.auteur = auteur;
            ViewBag.categorie = categorie;
            ViewBag.sortOrder = sortOrder;
            var livres = livreService.GetLivres();

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Titre";
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            if(!String.IsNullOrEmpty(titre)) values.Add("Titre", titre);
            if(!String.IsNullOrEmpty(auteur)) values.Add("Auteur.Nom", auteur);
            if (!String.IsNullOrEmpty(categorie)) values.Add("Categorie.Libelle", categorie);

            livres = livreService.FindBySearch(values, sortOrder);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(livres.ToPagedList(pageNumber, pageSize));
        }
    }
}