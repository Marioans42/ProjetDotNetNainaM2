using Modeles;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


           /* Livre livre = new Livre();
            livre.titre = "Harry Potteur";
            livre.description = "Harry ";
            livre.dapparution = null;
            livre.categorie = null;
            livre.auteur = null;
            LivreService.AjoutLivre(livre);*/
            IEnumerable<Livre> liste = LivreService.GetAllLivres();
            foreach(var item in liste)
            {
                Console.WriteLine(item.titre);
            }
            Console.ReadKey();
        }
    }
}
