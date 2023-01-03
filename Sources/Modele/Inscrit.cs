using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Model;
using System.Threading.Tasks;


namespace Model
{
    /// <summary>
    /// Permet de représenter une personne inscrit à l'application.
    /// </summary>
    public class Inscrit
    {
        /// <summary>
        /// Représente l'identifiant de l'inscrit.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Représente le prénom de l'inscrit.
        /// </summary>
        public string Prenom { get; private set; }

        /// <summary>
        /// Représente le nom de l'inscrit.
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Représente l'adresse mail de l'inscrit.
        /// </summary>
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

        /// <summary>
        /// Représente le mot de passe de l'inscrit pour se connecter à son compte.
        /// </summary>
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

        /// <summary>
        /// Représente la solde total de l'inscrit.
        /// </summary>
        public double SoldeTotal { get; private set; }

        /// <summary>
        /// Type de monnaie pour laquel est le solde total.
        /// </summary>
        public Devises Dev { get; private set; }

        /// <summary>
        /// Liste des banques pour laquel l'inscrit à un compte.
        /// </summary>
        public List<Banque> LesBanques { get; private set; } = new List<Banque>();

        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal = 0)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
        }
        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal, List<Banque> lesbanques)
            : this(id, nom, mail, prenom, mdp, soldeTotal)
        {
            LesBanques = lesbanques;
        }

        /// <summary>
        /// Permet d'ajouter une banque à la liste LesBanques
        /// </summary>
        /// <param name="banque">objet de type banque correspondant à la banque qui doit être rajouté dans la liste</param>
        public void ajouterBanque(Banque banque)
        {
            LesBanques.Add(banque);
        }

        /// <summary>
        /// Permet de supprimer une banque de la liste LesBanques
        /// </summary>
        /// <param name="banque"> Objet de type banque correspondant à la banque qui doit être supprimé de la liste.</param>
        public void SupprimerBanque(Banque banque)
        {
            LesBanques.Remove(banque);

        }

        /// <summary>
        /// Permet de changer la devise utilisé pour le solde total
        /// </summary>
        /// <param name="devise">Correspond à la devise devant être utilisé.</param>
        public void ChoisirDevise(Devises devise)
        {
            Dev = devise;
        }

    }
}
