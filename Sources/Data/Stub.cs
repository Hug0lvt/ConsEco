using Model;

namespace Data
{
    public class Stub : IPersistanceManager
    {
        public string GetId(string mail)
        {
            return "1";
        }
        public void SupprimerInscritBdd(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public void SupprimerBanqueBdd(Inscrit inscrit, Banque banque)
        {
            throw new NotImplementedException();
        }
        public void SupprimerToutesBanquesBdd(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public void CreateInscrit(Inscrit inscrit){}
        public string LastInscrit()
        {
            return "1";
        }
        public bool ExistEmail(string mail)
        {
            return true;
        }
        public void ChangePasswordBdd(string mail, string newMdp)
        {
            throw new NotImplementedException();
        }
        public string RecupMdpBdd(string mail)
        {
            return "61202106183104184172149183829180134166241997147151111351903525172892257223616564213999421532841808077145252175106506275806214514321147161111472321892055913517616241";
        }
        public int CalculTotalSoldeComtpe(Inscrit user)
        {
            return 0;
        }
        public List<Banque> LoadBanqueId(string id)
        {
            List<Banque> lesBanques = new List<Banque>();
            lesBanques.Add(new Banque("Credit Agricole","azerty.com","aaacom"));
            lesBanques.Add(new Banque("Credit Mutuel", "azerty.com", "aaacom"));
            return lesBanques;
        }
        public bool TestConnexionAsDatabase()
        {
            return true;
        }
        public List<Banque> ImportBanques()
        {
            List<Banque> lesBanques = new List<Banque>();
            lesBanques.Add(new Banque("Credit Agricole", "azerty.com", "aaacom"));
            lesBanques.Add(new Banque("Credit Mutuel", "azerty.com", "aaacom"));
            lesBanques.Add(new Banque("CIC", "azerty.com", "aaacom"));
            lesBanques.Add(new Banque("BNP", "azerty.com", "aaacom"));
            lesBanques.Add(new Banque("OrangeBank", "azerty.com", "aaacom"));
            return lesBanques;
        }

        public Inscrit GetInscrit(string mail)
        {
            string mdp = "Azerty12345678!";
            Inscrit i = new Inscrit("1", "LIVET", "livet.hugo2003@gmail.com", "Hugo", mdp);

            return i;
        }

        public IList<Compte> GetCompteFromOFX(string ofx)
        {
            return LoadOperation.LoadOperationsFromOFX(ofx);
        }
    }
}



