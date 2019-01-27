using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.ViewModels
{
    public class CreateLivreVueModele
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date d'apparution")]
        public DateTime Dapparution { get; set; }
        public string SelectedCategorie { get; set; }
        public string SelectedAuteur { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Auteurs { get; set; }
    }
}