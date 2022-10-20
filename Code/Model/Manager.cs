using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manager : INotifyPropertyChanged
    {
        public Manager() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        public IReadOnlyCollection<Inscrit> ListedesInscrits { get; private set; }
        private List<Inscrit> TousLesInscrits { get; set; } = new List<Inscrit>();
        public IReadOnlyCollection<Banque> ListeDesBanques { get; private set; }
        private List<Banque> TouteLesBanques { get; set; } = new List<Banque>();

        public IPersistanceManager Pers { get; private set; }


        public Inscrit SelectedInscrits
        {
            get => selectedInscrits;
            set
            {
                if (selectedInscrits != value)
                {
                    selectedInscrits = value;
                    OnPropertyChanged(nameof(SelectedInscrits));
                }
            }
        }
        private Inscrit selectedInscrits;

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

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public void LoadInscrit()
        {
            TousLesInscrits.Clear();
            TousLesInscrits.AddRange(Pers.LoadInscrit());
            if (TousLesInscrits.Count > 0)
                SelectedInscrits = TousLesInscrits.First();

        }

        public void LoadBanque()
        {
            TouteLesBanques.Clear();
            TouteLesBanques.AddRange(Pers.LoadBanque());
            if (TouteLesBanques.Count > 0)
                SelectedBanque = TouteLesBanques.First();
        }

        public Manager(IPersistanceManager persistance)
        {
            ListedesInscrits = new ReadOnlyCollection<Inscrit>(TousLesInscrits);
            ListeDesBanques = new ReadOnlyCollection<Banque>(TouteLesBanques);
            Pers = persistance;
        }

        public void supprimerInscritBdd(Inscrit i)
        {
            Pers.SupprimerInscritBdd(i);
        }

        public void supprimerBanqueBdd(Inscrit i, Banque b)
        {
            Pers.SupprimerBanqueBdd(i, b);
        }

        /*     public void supprimerInscritBdd(Inscrit i)
             {


             }*/


    }

}
