using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Npgsql;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public IPersistanceManager Pers { get; private set; }
        public string SelectedInscrits;

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
            SelectedInscrits = Pers.LoadInscrit(id, mdp);
        }



    }

}
