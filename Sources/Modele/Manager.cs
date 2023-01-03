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

        public Hash hash = new Hash();

        public int Solde
        {
            get => solde;
            set
            {
                if (solde != value)
                {
                    solde = value;
                    OnPropertyChanged(nameof(Solde));
                }
            }
        }

        private int solde;

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
        public List<Banque> BanquesDisponibleInApp
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
        private List<Banque> banquesDisponibleInApp;

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Manager(IPersistanceManager persistance)
        {
            Pers = persistance;
        }

        

        public bool isEqualHash(string mdpBdd, string mdpSent)
        {
            return hash.IsEqualHash(mdpBdd, mdpSent);
        }

        

        public void deconnexion()
        {
            User = null;
        }



    }
}

