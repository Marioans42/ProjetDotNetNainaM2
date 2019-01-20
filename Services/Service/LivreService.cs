using Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class LivreService
    {
        
        public static void AjoutLivre(Livre livre)
        {
            using (var context = new ProjetContext()) {
                context.Livres.Add(livre);
                context.SaveChanges();
 
            }
           
        }

        public static Livre GetLivre(int id)
        {
            using (var context = new ProjetContext())
            {
                var livre = context.Livres.FirstOrDefault(a => a.id == id);
                return livre;
            }
            
        }

        public static IEnumerable<Livre> GetAllLivres() {
            IEnumerable<Livre> livre;
            using (var context = new ProjetContext())
            {
                return livre = context.Livres.ToList();
 
            }
        }
    }
}
