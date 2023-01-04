using System.ComponentModel;

namespace Model
{
    /// <summary>
    /// Permet de faire le lien entre le modèle et la base de donnée..
    /// </summary>
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IPersistanceManager Pers { get; private set; }

        /// <summary>
        /// L'inscrit chargé venant de la base de donnée.
        /// </summary>
        public string SelectedInscrit { get; set; }

        /// <summary>
        /// Permet d'utiliser les fonctions de hachage.
        /// </summary>
        public Hash hash = new Hash();

        public Banque SelectedBanque
        {
            get => selectedBanque;
            set
            {
                if(selectedBanque != value)
                {
                    selectedBanque = value;
                    OnPropertyChanged(nameof(selectedBanque));
                }
            }
        }
        private Banque selectedBanque;
        

        /// <summary>
        /// A compléter
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Manager(IPersistanceManager persistance)
        {
            Pers = persistance;
        }




        /// <summary>
        /// Permet la supression d'un inscrit de la base de donnée.
        /// </summary>
        /// <param name="i">L'inscrit devant être supprimé de la base de donnée.</param>
        public void SupprimerInscritBdd(Inscrit i)
        {
            Pers.SupprimerInscritBdd(i);
        }

        /// <summary>
        /// Permet de charger un inscrit de la base de donnée et le place dans SelectedInscrit.
        /// </summary>
        /// <param name="id">L'identifiant de l'inscrit devant être chargé.</param>
        /// <param name="mdp">Le mot de passe de l'inscrit devant être chargé.</param>
        public void LoadInscrit(string id, string mdp)
        {
            SelectedInscrit = Pers.LoadInscrit(id, mdp);
        }

        /// <summary>
        /// Permet de supprimer toute les banques de la base de donnée pour un inscrit placé en paramètre
        /// </summary>
        /// <param name="inscrit">L'inscrit pour lequel toute les banques doivent être supprimé.</param>
        public void supprimerToutesBanquesBdd(Inscrit inscrit)
        {
            Pers.SupprimerToutesBanquesBdd(inscrit);
        }

        /// <summary>
        /// Ajoute un inscrit dans la base de donnée
        /// </summary>
        /// <param name="inscrit">L'inscrit devant être stocké dans la base de donnée.</param>
        public void createInscrit(Inscrit inscrit)
        {
            Pers.CreateInscrit(inscrit);
        }

        /// <summary>
        /// A complété
        /// </summary>
        /// <returns></returns>
        public string lastInscrit()
        {
            return Pers.LastInscrit();
        }

        /// <summary>
        /// Cherche à vérifier si le mail posté en paramètre existe dans la base de donnée
        /// </summary>
        /// <param name="mail">Mail posté par la personne.</param>
        /// <returns>Renvoie true si le mail est bien stocké dans la base de donnée</returns>
        public bool existEmail(string mail)
        {
            return Pers.ExistEmail(mail);
        }

        /// <summary>
        /// Permet de changer le mot de passe dans la base de donnée pour la mail placé en paramètre.
        /// </summary>
        /// <param name="mail">Mail posté par la personne.</param>
        /// <param name="newMdp">Nouveau mot de passe devant être stocké dans la base de donnée</param>
        public void changePasswordBdd(string mail, string newMdp)
        {
            Pers.ChangePasswordBdd(mail, newMdp);
        }

        /// <summary>
        /// Permet d'obtenir le mot de passe dans la base de donnée d'un mail donnée.
        /// </summary>
        /// <param name="mail">Mail pour laquel on souhaite obtenir le mot de passe.</param>
        /// <returns>Renvoie le mot de passe haché recherché.</returns>
        public string recupMdpBdd(string mail)
        {
            return Pers.RecupMdpBdd(mail);
        }

        /// <summary>
        /// Permet de comparer un mot de passe de la base de donnée avec un mot de passe posté par l'utilisateur.
        /// </summary>
        /// <param name="mdpBdd">Représente le mot de passe haché de la base de donnée.</param>
        /// <param name="mdpSent">Représente le mot de passe posté par l'utilisateur.</param>
        /// <returns>Retourne un booleen égale à True si les deux mots de passe sont les mêmes</returns>
        public bool isEqualHash(string mdpBdd, string mdpSent)
        {
            return hash.IsEqualHash(mdpBdd, mdpSent);
        }

    }
}
