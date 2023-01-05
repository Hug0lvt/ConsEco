using Model;

namespace Data
{
    public class PersStub /*: IPersistanceManager*/
    {
        private List<Inscrit> lesInscrits = new List<Inscrit>();

        public PersStub()
        {
            lesInscrits.Add(new Inscrit(
                1,
                "LIVET",
                "livet.hugo2003@gmail.com",
                "Hugo",
                "Bonjour63."
                ));
        }
        public int GetId(string mail)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if(i.Mail == mail)
                {
                    return i.Id;
                }
            }
            return -1;
        }
        public void SupprimerInscritBdd(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public void SupprimerBanqueBdd(Inscrit inscrit, Banque banque)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if (i == inscrit)
                {
                    foreach(Banque b in i.LesBanques)
                    {
                        if(b == banque)
                        {
                            i.SupprimerBanque(b);
                        }
                    }
                }
            }
        }
        public void SupprimerToutesBanquesBdd(Inscrit inscrit)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if(i == inscrit)
                {
                    foreach(Banque b in i.LesBanques)
                    {
                        i.SupprimerBanque(b);
                    }
                }
            }
        }
        public void CreateInscrit(Inscrit inscrit){
            lesInscrits.Add(inscrit);
        }
        /*public string LastInscrit()
        {
            return lesInscrits[lesInscrits.Count - 1].Id;
        }*/
        public bool ExistEmail(string mail)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if(i.Mail == mail)
                {
                    return true;
                }
            }
            return false;
        }
        public void ChangePasswordBdd(string mail, string newMdp)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if(i.Mail == mail)
                {
                    i.Mdp = newMdp;
                }
            }
        }
        public string RecupMdpBdd(string mail)
        {
            foreach(Inscrit i in lesInscrits)
            {
                if(i.Mail == mail)
                {
                    return Hash.CreateHashCode(i.Mdp);
                }
            }
            return "inexistant";
        }
        public int CalculTotalSoldeComtpe(Inscrit inscrit)
        {
            int totalSoldeComtpe = 0;
            foreach(Inscrit i in lesInscrits)
            {
                if(i == inscrit)
                {
                    foreach(Banque b in i.LesBanques)
                    {
                        totalSoldeComtpe = b.ListeDesComptes.Sum(x => Convert.ToInt32(x));
                    }
                }
            }
            return totalSoldeComtpe;
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
            foreach(Inscrit i in lesInscrits)
            {
                if(i.Mail == mail)
                {
                    return i;
                }
            }
            return null; 
        }

        public IList<Compte> GetCompteFromOFX(string ofx)
        {
            return LoadOperation.LoadOperationsFromOFX(ofx);
        }



        public List<Banque> LoadBanqueId(int id)
        {
            throw new NotImplementedException();
        }
    }
}



