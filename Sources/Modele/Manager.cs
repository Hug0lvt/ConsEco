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
                    LoadBanque();
                }
            }
        }
        private Inscrit user;

        public BanqueInscrit SelectedBanque
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
        private BanqueInscrit selectedBanque;
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


        private IList<BanqueInscrit> listeDesBanques = new List<BanqueInscrit>();
        public ReadOnlyCollection<BanqueInscrit> AllBanque { get; private set; }


        private List<Compte> listeDesComptes = new List<Compte>();
        
        public ReadOnlyCollection<Compte> AllCompte { get; private set; }


        public Manager(IPersistanceManager persistance)
        {
            AllBanque = new ReadOnlyCollection<BanqueInscrit>(listeDesBanques);
            AllCompte = new ReadOnlyCollection<Compte>(listeDesComptes);
            Pers = persistance;
        }



        

        public async void LoadCompte()
        {
            
            listeDesComptes.Clear();

            if(SelectedBanque == null)
            {
                  throw new ArgumentNullException("Vous n'avez pas de banque disponible");
            }

            try
            {
                IList<Compte> comptes = await Pers.RecupererCompte(SelectedBanque);  
                listeDesComptes.AddRange(comptes);
                foreach (Compte compte in listeDesComptes)
                {
                    
                    compte.LesPla = await Pers.RecupererPlanification(compte);
                    compte.LesOpe = await Pers.RecupererOperation(compte);
                    compte.LesEch = await Pers.RecupererEcheance(compte);

                }

                if (listeDesComptes.Count > 0)
                {
                    selectedCompte = listeDesComptes.First();
                }

                SelectedCompte = listeDesComptes.FirstOrDefault();
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            
        }

        public async void LoadBanque()
        {
            try
            {
                listeDesBanques = await Pers.RecupererBanques(User);
                SelectedBanque = listeDesBanques.FirstOrDefault();

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
          
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

        /*public async void LoadBanques()
        {
            User.LesBanques = await Pers.RecupererBanques(User);
            BanquesDisponibleInApp = await Pers.RecupererBanquesDisponible();
        }*/

        public async Task<string> getPassword(string email)
        {
            Inscrit inscrit = await Pers.RecupererInscrit(email);
            return inscrit.Mdp;
        }

        public async void createUser(string mail)
        {
            User = await Pers.RecupererInscrit(mail);
        }



        // Intégralité des méthodes (Débit, Crédit, planification echeance)

        public void effectuerOperation(Compte compte, Operation operation)
        {
            Pers.AjouterOperation(compte, operation);
        }

        public void supprimerOperation(Compte compte, Operation operation)
        {
            Pers.SupprimerOperation(compte, operation);
        }
    
    }
}

