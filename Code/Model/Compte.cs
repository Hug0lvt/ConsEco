namespace Model
{
    public class Compte
    {
        public string Nom { get; private set; }
        public double Solde { get; private set; }

        public Compte(string nom, double solde)
        {
            Nom = nom;
            Solde = solde;
        }
    }
}