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
        public IReadOnlyCollection<Inscrit> ListedesInscrits { get; private set; }
        private List<Inscrit> TousLesInscrits { get; set; } = new List<Inscrit>();

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public Inscrit SelectedInscrits
        {
            get => selectedInscrits;
            set
            {
                if(selectedInscrits != value)
                {
                    selectedInscrits = value;
                    OnPropertyChanged(nameof(SelectedInscrits));
                }
            }
        }
        private Inscrit selectedInscrits;

        public Manager(IReadOnlyCollection<Inscrit> listedesInscrits, List<Inscrit> tousLesInscrits, Inscrit selectedInscrits)
        {
            ListedesInscrits = listedesInscrits;
            TousLesInscrits = tousLesInscrits;
            this.selectedInscrits = selectedInscrits;
          
        }

        /*En attente de la persistance*/

        /*   public Manager(IPersistanceManager persistance)
           {
               ListedesInscrits = new ReadOnlyCollection<Inscrit>(TousLesInscrits);
               persistance = persistance;
           }*/

    }

}
