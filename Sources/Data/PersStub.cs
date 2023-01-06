using Model;

namespace Data
{
    public class PersStub : IPersistanceManager
    {
        /*private List<Inscrit> lesInscrits = new List<Inscrit>();

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
        }*/
        public bool AjouterBanque(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool AjouterCompte(Compte compte, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool AjouterEcheance(Compte compte, Echeance echeance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AjouterInscrit(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool AjouterOperation(Compte compte, Operation operation)
        {
            throw new NotImplementedException();
        }

        public bool AjouterPlanification(Compte compte, Planification planification)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmailDisponible(string mail)
        {
            throw new NotImplementedException();
        }

        public IList<Compte> GetDataFromOFX(string path)
        {
            throw new NotImplementedException();
        }

        public bool ModifierMdpInscrit(string mail, string nouveauMdp)
        {
            throw new NotImplementedException();
        }

        public IList<Banque> RecupererBanques(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public IList<Banque> RecupererBanquesDisponible()
        {
            throw new NotImplementedException();
        }

        public IList<Compte> RecupererCompte(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public IList<Echeance> RecupererEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }

        public Inscrit RecupererInscrit(string mail)
        {
            throw new NotImplementedException();
        }

        public IList<Operation> RecupererOperation(Compte compte)
        {
            throw new NotImplementedException();
        }

        public IList<Planification> RecupererPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerBanque(Banque banque, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerCompte(Compte compte, Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerEcheance(Compte compte, Echeance echeance)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerInscrit(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerOperation(Compte compte, Operation operation)
        {
            throw new NotImplementedException();
        }

        public bool SupprimerPlanification(Compte compte, Planification planification)
        {
            throw new NotImplementedException();
        }

        public bool TestConnexion()
        {
            throw new NotImplementedException();
        }
    }
}



