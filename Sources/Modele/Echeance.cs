using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Echeance
    {

        public string IntituleOperation { get; private set; }

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }

        [JsonConstructor]
        public Echeance(string intituleOperation, double montant, DateTime dateOperation, MethodePayement modePayement, bool isDebit = true)
        {
            IntituleOperation = intituleOperation;
            Montant = montant;
            DateOperation = dateOperation;
            ModePayement = modePayement;
            IsDebit = isDebit;
        }

        public override string ToString()
        {
            return IntituleOperation + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit;
        }

    }
}
