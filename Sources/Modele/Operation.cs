using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Operation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Nom 
        {
            get => nom;
            set
            {
                if (nom != value)
                {
                    nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }
        private string nom;

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }

        public TagOperation Tag { get; private set; }

        public bool FromBanque { get; private set; }

        [JsonConstructor]
        public Operation(string nom, double montant, DateTime dateO, MethodePayement methodePayement, TagOperation tag, bool fromBanque, bool isDebit=true)
        {
            Nom = nom;
            Montant = montant;
            DateOperation = dateO;
            ModePayement = methodePayement;
            IsDebit = isDebit;
            Tag = tag;
            FromBanque = fromBanque;
        }

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return Nom + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit + " " + FromBanque + " " + Tag;
        }




    }
}