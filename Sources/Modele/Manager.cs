using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Model
{
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IPersistanceManager Pers { get; private set; }

        public int SelectedInscrit { get; set; }

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

        public Manager(IPersistanceManager persistance)
        {
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

        public void LoadBanques()
        {
            BanquesDisponibleInApp = Pers.RecupererBanquesDisponible();
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

