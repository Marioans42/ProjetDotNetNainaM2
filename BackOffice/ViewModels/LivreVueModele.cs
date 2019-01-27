using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modeles;

namespace BackOffice.ViewModels
{
    public class LivreVueModele
    {
        public Livre Livre { get; set; }
        public string SelectedCategorie { get; set; }
        public string SelectedAuteur { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Auteurs { get; set; }
    }
}