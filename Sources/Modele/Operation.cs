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
        public string IntituleOperation 
        {
            get => intituleOperation;
            set
            {
                if (intituleOperation != value)
                {
                    intituleOperation = value;
                    OnPropertyChanged(nameof(IntituleOperation));
                }
            }
        }
        private string intituleOperation;

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }

        [JsonConstructor]
        public Operation(string intituleOperation, double montant, DateTime dateOperation, MethodePayement modePayement, bool isDebit=true)
        {
            IntituleOperation = intituleOperation;
            Montant = montant;
            DateOperation = dateOperation;
            ModePayement = modePayement;
            IsDebit = isDebit;
        }

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return IntituleOperation + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit;
        }
    }
}