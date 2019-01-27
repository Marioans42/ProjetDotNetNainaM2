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
            var email = "admin@gmail.com";
            var mdp = "admin123";
            var hashMdp1 = Sha256(mdp);
            var hashMdp2 = Sha256(mdp);
            Console.WriteLine(hashMdp1);
            Console.WriteLine(hashMdp2);

            var utilisateur = UtilisateurService.FindAll().Where(u => u.Email.Equals(email) && u.Mdp.Equals(hashMdp1));

            Console.WriteLine(utilisateur.Count());
            Console.ReadKey();
        }

        public static string Sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
