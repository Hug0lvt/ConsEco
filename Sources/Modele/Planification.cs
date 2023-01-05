using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Planification
    {
        public string IntituleOperation { get; private set; }

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }
        public TagOperation Tag { get; private set; }

        [JsonConstructor]
        public Planification(string intituleOperation, double montant, DateTime dateOperation, MethodePayement modePayement, TagOperation tag, bool isDebit = true)
        {
            IntituleOperation = intituleOperation;
            Montant = montant;
            DateOperation = dateOperation;
            ModePayement = modePayement;
            IsDebit = isDebit;
            Tag = tag;
        }

        public override string ToString()
        {
            return IntituleOperation + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit + " " + Tag;
        }
    }
}
