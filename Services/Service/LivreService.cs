using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Modeles;
using Repositories;
using Repositories.DAL;

namespace Services.Service
{
    public class LivreService : LivreRepository
    {
        public LivreService(ProjetContext context) : base(context)
        {

        }

        public IEnumerable<Livre> FindBySearch(Dictionary<string, string> values, string orderBy)
        {
            var livres = this.GetLivres();
            foreach(var v in values)
            {
                livres = livres.Where(
                    l => CheckResearch(l, v.Key.ToString()).StartsWith(v.Value.ToString().ToLower())
                );
            }

            livres = livres.OrderBy(l => OrderBy(l, orderBy));

            return livres;
        }

        private string CheckResearch(Livre livre, string key)
        {
            string[] columns = key.Split('.');

            if (columns.Length > 1)
            {
                var field = livre.GetType().GetProperty(columns[0]).GetValue(livre);
                return field.GetType().GetProperty(columns[1]).GetValue(field).ToString().ToLower();
            }
            else
            {
                return livre.GetType().GetProperty(columns[0]).GetValue(livre).ToString().ToLower();
            }
        }

        private string OrderBy(Livre livre, string column)
        {
            string[] orders = column.Split('.');

            if (orders.Length > 1)
            {
                var field = livre.GetType().GetProperty(orders[0]).GetValue(livre);
                return field.GetType().GetProperty(orders[1]).GetValue(field).ToString().ToLower();
            }
            else
            {
                return livre.GetType().GetProperty(orders[0]).GetValue(livre).ToString().ToLower();
            }
        }
    }
}
