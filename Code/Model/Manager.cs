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

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public void LoadInscrit()
        {
            TousLesInscrits.Clear();
            TousLesInscrits.AddRange(Pers.LoadInscrit());
            if (TousLesInscrits.Count > 0)
                SelectedInscrits = TousLesInscrits.First();

        }

        public Manager(IPersistanceManager persistance)
        {
            ListedesInscrits = new ReadOnlyCollection<Inscrit>(TousLesInscrits);
            Pers = persistance;
        }

        public void supprimerInscritBdd(Inscrit i)
        {
            Pers.SupprimerInscritBdd(i);
        }

        /*     public void supprimerInscritBdd(Inscrit i)
             {


             }*/


    }

}
