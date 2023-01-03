using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Permet la création d'instances de banques.
    /// </summary>
    public class Banque
    {
        /// <summary>
        /// Nom est un string servant à identifier une banque.
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// UrlSite sert à identifier l'URL du site de la banque.
        /// </summary>
        public string UrlSite { get; private set; }

        /// <summary>
        /// UrlLogo sert à obtenir le logo de la banque.
        /// </summary>
        public string UrlLogo { get; private set; }

        /// <summary>
        /// ListeDesComptes sert à stocker tous les comptes dont dispose la personne sur cet banque.
        /// </summary>
        public List<Compte> ListeDesComptes { get; private set; } = new List<Compte>();

        public Banque(string nom, string urlSite, string urlLogo)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
        }

        public Banque(string nom, string urlSite, string urlLogo, List<Compte>lescomptes)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
            ListeDesComptes = lescomptes;
        }

        /// <summary>
        /// Permet d'ajouter un compte à ListeDesComptes
        /// </summary>
        /// <param name="compte"> Compte à ajouter à la liste ListeDesComptes </param>
        public void AjouterCompte(Compte compte)
        {
            ListeDesComptes.Add(compte);
        }

        /// <summary>
        /// Permet de supprimer un compte à ListeDesComptes 
        /// </summary>
        /// <param name="compte"> Représente le compte qui doit être supprimer de ListeDesComptes. </param>
        public void SupprimerCompte(Compte compte)
        {
            ListeDesComptes.Remove(compte);
        }

        /// <summary>
        /// Permet de vérifier si un compte dont le nom est passé en paramètre existe bien dans ListeDesComptes.
        /// </summary>
        /// <param name="s"> Nom du compte dont on souhaite savoir si il est présent dans ListeDesComptes. </param>
        /// <returns> Boolean égale à True si le compte existe dans la liste.</returns>
        public bool ExisteCompte(string s)
        {
            foreach (Compte compte in ListeDesComptes)
            {
                if (compte.Nom.Equals(s))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Permet d'obtenir le compte dont le nom est passé en paramètre dans la ListeDesComptes.
        /// </summary>
        /// <param name="s"> Nom du compte que l'on souhaite retourner. </param>
        /// <returns> L'objet de type compte que l'on souhaite retourner. </returns>

        public Compte ReturnCompte(string s)
        {
            foreach (Compte compte in ListeDesComptes)
            {
                if (compte.Nom.Equals(s))
                    return compte; 
            }
            throw new KeyNotFoundException();
        }
    }
}
