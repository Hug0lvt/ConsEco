using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Model
{
    /// <summary>
    /// Permet de faire le lien entre le modèle et la base de donnée..
    /// </summary>
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IPersistanceManager Pers { get; private set; }

        private Inscrit user;
        public Inscrit User
        {
            get
            {
                return user;
            }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public Banque SelectedBanque
        {
            get => selectedBanque;
            set
            {
                if (selectedBanque != value)
                {
                    selectedBanque = value;
                    OnPropertyChanged(nameof(SelectedBanque));
                }
            }
        }
        private Banque selectedBanque;
        public IList<Banque> BanquesDisponibleInApp
        {
            get => banquesDisponibleInApp;
            set
            {
                if (banquesDisponibleInApp != value)
                {
                    banquesDisponibleInApp = value;
                    OnPropertyChanged(nameof(BanquesDisponibleInApp));
                }
            }
        }
        private IList<Banque> banquesDisponibleInApp;



        //Test

/*
        private List<Compte> listeDesComptes = new List<Compte>();
        public ReadOnlyCollection<Compte> AllCompte { get; private set; }
*/

        public Manager(IPersistanceManager persistance)
        {
           // AllCompte = new ReadOnlyCollection<Compte>(listeDesComptes);
            Pers = persistance;
        }


      



        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public bool CompareHash(string mdpBdd, string mdpSent)
        {
            return Hash.IsEqualHash(mdpBdd, mdpSent);
        }

        public void deconnexion()
        {
            User = null;
        }

        public async void LoadBanques()
        {
            User.LesBanques = await Pers.RecupererBanques(User);
            BanquesDisponibleInApp = await Pers.RecupererBanquesDisponible();
        }

        public async Task<string> getPassword(string email)
        {
            Inscrit inscrit = await Pers.RecupererInscrit(email);
            return inscrit.Mdp;
        }

        public async void createUser(string mail)
        {
            User = await Pers.RecupererInscrit(mail);
        }
    }
}

