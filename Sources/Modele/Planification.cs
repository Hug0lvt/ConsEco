using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Planification 
    {
        
        public string Nom { get; private set; }

        public double Montant { get; private set; }

        public DateTime DateOperation { get; private set; }

        public MethodePayement ModePayement { get; private set; }

        public bool IsDebit { get; private set; }
        public TagOperation Tag { get; private set; }

        [JsonConstructor]
        public Planification(string nom, double montant, DateTime dateO, MethodePayement methodePayement, TagOperation tag, bool isDebit = true)
        {
            Nom = nom;
            Montant = montant;
            DateOperation = dateO;
            ModePayement = methodePayement;
            IsDebit = isDebit;
            Tag = tag;
        }

        public override string ToString()
        {
            return Nom + " " + DateOperation + " " + Montant + " " + ModePayement + " " + IsDebit + " " + Tag;
        }
    }
}
