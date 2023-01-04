using Microsoft.Maui.Graphics;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Model
{
    public class Compte : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Identifiant { get; set; }
        public string Nom { get; set; }
        public double Solde { get; set; }
        public DateTime DerniereModification { get; set; }
        public List<Operation> LesOpe 
        {
            get => lesOpe;
            set
            {
                if (lesOpe != value)
                {
                    lesOpe = value;
                    OnPropertyChanged(nameof(LesOpe));
                }
            }
        } 
        private List<Operation> lesOpe = new List<Operation>();
        public List<Planification> LesPla { get; set; } = new List<Planification>();
        public List<Echeance> LesEch { get; set; } = new List<Echeance>();
        public Compte(string id,string nom, double solde)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesOpe = lesOpe;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesPla = lesPla;
            LesOpe = lesOpe;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla, List<Echeance> lesEch)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesPla = lesPla;
            LesOpe = lesOpe;
            LesEch = lesEch;
        }

        
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ajouterOperation(Operation o)
        {
            if (o == null) throw new NullReferenceException();
            LesOpe.Add(o);
        }

        public void cacherOperation(Operation o)
        {
            throw new NotImplementedException();
        }

        public void supprimerOperation(Operation o)
        {
            LesOpe.Remove(o);
        }

        public void ajoutEcheance(Echeance e)
        {
            if (e == null) throw new NullReferenceException();
            LesEch.Add(e);
        }

        public void supprimerEcheance(Echeance e)
        {
            LesEch.Remove(e);
        }

        public void ajoutPlannification(Planification p)
        {
            if (p == null) throw new NullReferenceException();
            LesPla.Add(p);
        }

        public void supprimerPlannification(Planification p)
        {
            LesPla.Remove(p);
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Compte objCompte = (Compte) obj;
                if(objCompte.Identifiant == Identifiant && objCompte.DerniereModification == DerniereModification) return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Identifiant + " " + Nom + " " + Solde + " "  + DerniereModification + "\n";
        }

    }
}