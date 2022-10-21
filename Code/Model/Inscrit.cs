using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Banque;

namespace Model
{
    public class Inscrit
    {

        public string Id { get; private set; }
        public string Nom { get; private set; }

        public string Mail
        {
            get => mail;
            set
            {
                if (value.Length == 0)
                {
                    throw new InvalidMailException(value, "Longueur d'un mail doit être superieur a 0");
                }
                if (!Regex.IsMatch(value, "(@)(.+)"))
                {
                    throw new InvalidMailException(value, "Un mail doit contenir le symbole '@'");
                }
                mail = value;
            }
        }
        private string mail;

        public string Prenom { get; private set; }

        public string Mdp
        {
            get => mdp;
            set
            {
                if (value.Length <= 8)
                {
                    throw new InvalidPasswordException(value, "La longeur d'un mot de passe doit être obligatoirement superieure a 8");
                }
                if (!Regex.IsMatch(value, "[A-Z]+"))
                {
                    throw new InvalidPasswordException(value, "Le mot de passe doit contenir au moins une lettre majuscule");
                }
                if (!Regex.IsMatch(value, "[0-9]+"))
                {
                    throw new InvalidPasswordException(value, "Le mot de passe doit contenir au moins un chiffre");
                }
                mdp = value;
            }
        }
        private string mdp;

        public double SoldeTotal { get; private set; }
        public Devises Dev { get; private set; }
        public List<Banque> LesBanques { get; private set; } = new List<Banque>();

        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
        }
        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal,List<Banque>lesbanques)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
            LesBanques = lesbanques;
        }

        public void ajouterBanque(Banque banque)
        {
            LesBanques.Add(banque);
        }

        public void SupprimerBanque(Banque banque)
        {
            LesBanques.Remove(banque);
        }

        public void ChoisirDevise(Devises devise)
        {
            Dev = devise;
        }

    }
}
