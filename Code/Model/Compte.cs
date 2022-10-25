namespace Model
{
    public class Compte
    {
        public string Nom { get; private set; }
        public double Solde { get; private set; }
        public List<Operation> LesOpe { get; private set; } = new List<Operation>();
        public List<Planification> LesPla { get; private set; } = new List<Planification>();
        public List<Echeance> LesEch { get; private set; } = new List<Echeance>();
        public Compte(string nom, double solde)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = new List<Operation>();
            LesPla = new List<Planification>();
            LesEch = new List<Echeance>();
        }
        public Compte(string nom, double solde, List<Operation> lesOpe)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
        }
        public Compte(string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
            LesPla = lesPla;
        }
        public Compte(string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla, List<Echeance> lesEch)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
            LesPla = lesPla;
            LesEch = lesEch;
        }
        public void modifierSolde(double s)
        {
            Solde = s;
        }

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
            if(e == null) throw new NullReferenceException();
            LesEch.Add(e);
        }

        public void supprimerEcheance(Echeance e)
        {
            LesEch.Remove(e);
        }

        public void ajoutPlannification(Planification p)
        {
            if(p == null) throw new NullReferenceException();
            LesPla.Add(p);
        }

        public void supprimerPlannification(Planification p)
        {
            LesPla.Remove(p);
        }

        public override bool Equals(object? obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}