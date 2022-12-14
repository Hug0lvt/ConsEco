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

        public void SupprimerInscritBdd(Inscrit i)
        {
            Pers.SupprimerInscritBdd(i);
        }

        public string GetId(string mail)
        {
            return Pers.GetId(mail);
        }

        public void LoadBanques()
        {
            User.LesBanques = Pers.LoadBanqueId(User.Id);
            if (User.LesBanques.Count() > 0)
            {
                SelectedBanque = User.LesBanques[0];
            }
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

        public void createUser(string mail)
        {
            //User = new Inscrit(mail, GetId(mail));
            User = Pers.GetInscrit(mail);
        }

        public int recupTotalSolde()
        {
            Solde = Pers.CalculTotalSoldeComtpe(User);
            return Solde;
        }

        public void deconnexion()
        {
            User = null;
        }

        public bool testConnexionAsDatabase()
        {
            return Pers.TestConnexionAsDatabase();
        }

        public void importBanques()
        {
            BanquesDisponibleInApp = Pers.ImportBanques();
        }

        public IList<Compte> getCompteFromOFX(string ofx)
        {
            return Pers.GetCompteFromOFX(ofx);
        }

    }
}

