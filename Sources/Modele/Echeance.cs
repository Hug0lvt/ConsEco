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

        public string Nom { get; private set; }

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }
        public TagOperation Tag { get; private set; }

        [JsonConstructor]
        public Echeance(string nom, double montant, DateTime dateOperation, MethodePayement modePayement, TagOperation tag, bool isDebit = true)
        {
            Nom = nom;
            Montant = montant;
            DateOperation = dateOperation;
            ModePayement = modePayement;
            IsDebit = isDebit;
            Tag = tag;
        }

        public override string ToString()
        {
            return Nom + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit + " " + Tag;
        }

    }
}
