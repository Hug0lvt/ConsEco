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
        public event PropertyChangedEventHandler? PropertyChanged;
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

        public Manager(IPersistanceManager persistance)
        {
            SelectedInscrits = persistance.LoadInscrit();
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
