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



        public Compte SelectedCompte
        {
            get => selectedCompte;
            set
            {
                if(selectedCompte != value)
                {
                    selectedCompte = value;
                    OnPropertyChanged(nameof(SelectedCompte));
                }
            }
        }
        private Compte selectedCompte;


        private IList<Banque> listeDesBanques = new List<Banque>();
        public ReadOnlyCollection<Banque> AllBanque { get; private set; }


        private List<Compte> listeDesComptes = new List<Compte>();
        
        public ReadOnlyCollection<Compte> AllCompte { get; private set; }


        public Manager(IPersistanceManager persistance)
        {
            AllBanque = new ReadOnlyCollection<Banque>(listeDesBanques);
            AllCompte = new ReadOnlyCollection<Compte>(listeDesComptes);
            Pers = persistance;
        }



        

        public async void LoadCompte()
        {
            listeDesComptes.Clear();

            if(SelectedBanque == null || SelectedCompte == null)
            {
                  throw new ArgumentNullException("Vous n'avez pas de banque disponible");
            }

            try
            {
                IList<Compte> comptes = await Pers.RecupererCompte(SelectedBanque, User);  
                listeDesComptes.AddRange(comptes);
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
       
          
            foreach (var compte in listeDesComptes)
            {
                try
                {
                    compte.LesPla = await Pers.RecupererPlanification(compte);
                    compte.LesOpe = await Pers.RecupererOperation(compte);
                    compte.LesEch = await Pers.RecupererEcheance(compte);
                }
                catch(Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }
             

            }
         
        }

        public async void LoadBanque()
        {
            try
            {
                listeDesBanques = await Pers.RecupererBanques(User);
            }catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
          
            SelectedBanque = listeDesBanques.First();
        }

        public async void LoadBanqueDispo()
        {
            try
            {
                BanquesDisponibleInApp = await Pers.RecupererBanquesDisponible();
            }catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            
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

