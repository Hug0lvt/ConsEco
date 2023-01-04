using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Operation
    {
        public string Nom { get; private set; }
        public string Type { get; private set; }
        public string Tag { get; private set; }
        public double Montant { get; private set; }
        public string Date { get; private set; }


        public Operation(string nom, string type, string tag, string date, double montant)
        {
            Nom = nom;
            Type = type;
            Tag = tag;
            Date = DateTime.Now.ToString("dd/MM/yyyy");
            Montant = montant;
        }



    }
}
