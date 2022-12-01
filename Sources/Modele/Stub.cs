using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Stub //la classe n'implémante pas IPersistanceManager
    {
        public List<Banque> Banques = new();
        public List<Inscrit> Inscrits = new();
        public List<Compte> Comptes = new();
        //


        // ajouter load all pour tout les inscrits

        public List<Inscrit> LoadInscrit()
        {
            Inscrits.Add(new("00001", "Evard", "lucasevard@gmail.com","Lucas","test",10,LoadBanques()));
            Inscrits.Add(new("00002", "Livet", "hugolivet@gmail.com", "Hugo", "test", 280,LoadBanques()));
            Inscrits.Add(new("00003", "Smith", "smith@gmail.com", "Luke", "test", 150,LoadBanques()));
            Inscrits.Add(new("00004", "Jean", "jean@gmail.com", "sylvain", "test", 410,LoadBanques()));
            Inscrits.Add(new("00005", "Franc", "franc@gmail.com", "Julie", "test", 820,LoadBanques()));
            Inscrits.Add(new("00006", "March", "march@gmail.com", "bastien", "test", 1120,LoadBanques()));
            return Inscrits;
        }
        public List<Banque> LoadBanques()
        {
            Banques.Add(new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png",LoadCompte()));
            Banques.Add(new("Crédit Agricole", "https://www.credit-agricole.fr", "https://yt3.ggpht.com/a/AGF-l7_mEfX2eQaGm8GefLOg5ZMRciNw-pESE3gUWg=s900-c-k-c0xffffffff-no-rj-mo",LoadCompte()));
            return Banques;
        }
        public List<Compte> LoadCompte()
        {
            Comptes.Add(new("012345678901", "Livret A", 1500));
            Comptes.Add(new("012345678902", "Compte Courant", 2000));
            Comptes.Add(new("012345678903", "PEL", 22000));
            return Comptes;
        }

       
    }
}

