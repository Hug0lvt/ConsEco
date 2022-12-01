using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model
{
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IPersistanceManager Pers { get; private set; }

        public string SelectedInscrit { get; set; }

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

        public ObservableCollection<Banque> BanquesDisponibleInApp { get; set; } = new ObservableCollection<Banque>();

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Manager(IPersistanceManager persistance)
        {
            Pers = persistance;
        }

        public void SupprimerInscritBdd(Inscrit i)
        {
            Pers.SupprimerInscritBdd(i);
        }

        public void LoadInscrit(string id, string mdp)
        {
            SelectedInscrit = Pers.LoadInscrit(id, mdp);
        }

        public void supprimerToutesBanquesBdd(Inscrit inscrit)
        {
            Pers.SupprimerToutesBanquesBdd(inscrit);
        }

        public void createInscrit(Inscrit inscrit)
        {
            Pers.CreateInscrit(inscrit);
        }

        public string lastInscrit()
        {
            return Pers.LastInscrit();
        }

        public bool existEmail(string mail)
        {
            return Pers.ExistEmail(mail);
        }

        public void changePasswordBdd(string mail, string newMdp)
        {
            Pers.ChangePasswordBdd(mail, newMdp);
        }

        public string recupMdpBdd(string mail)
        {
            return Pers.RecupMdpBdd(mail);
        }

        public bool isEqualHash(string mdpBdd, string mdpSent)
        {
            return hash.IsEqualHash(mdpBdd, mdpSent);
        }

        public bool testConnexionAsDatabase()
        {
            return Pers.TestConnexionAsDatabase();
        }

        public IList<Banque> importBanques()
        {
            return Pers.ImportBanques();
        }
    }

}
