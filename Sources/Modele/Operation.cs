using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Operation
    {

        public string IntituleOperation { get; private set; }

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }
        
        public string IdCompte { get; private set; }

        public Operation(string intituleOperation, string idCompte, double montant, DateTime dateOperation, MethodePayement modePayement, bool isDebit=true)
        {
            IntituleOperation = intituleOperation;
            IdCompte = idCompte;
            Montant = montant;
            DateOperation = dateOperation;
            ModePayement = modePayement;
            IsDebit = isDebit;
        }

        public override string ToString()
        {
            return IdCompte + " " + IntituleOperation + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit + "\n";
        }
    }
}
