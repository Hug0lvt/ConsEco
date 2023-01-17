using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Banque : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Nom { get; private set; }

        /// <summary>
        /// UrlSite sert à identifier l'URL du site de la banque.
        /// </summary>
        public string UrlSite { get; private set; }

        /// <summary>
        /// UrlLogo sert à obtenir le logo de la banque.
        /// </summary>
        public string UrlLogo { get; private set; }
        public List<Compte> ListeDesComptes 
        {
            get => listeDesComptes;
            set
            {
                if (listeDesComptes != value)
                {
                    listeDesComptes = value;
                    OnPropertyChanged(nameof(ListeDesComptes));
                }
            } 
        }
        private List<Compte> listeDesComptes = new List<Compte>();

        [JsonConstructor]
        public Banque(string nom, string urlSite, string urlLogo)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
        }

        public Banque(string nom, string urlSite, string urlLogo, List<Compte> lescomptes) : this(nom,urlSite, urlLogo)
        {
            ListeDesComptes = lescomptes;
        }

       /* public Banque()
        {
        }
*/
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public override string ToString()
        {
            return Nom + " " + UrlSite + " " + UrlLogo;
        }

    }
}