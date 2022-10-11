using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Banque
    {
        public string Nom { get; private set; }
        public string UrlSite { get; private set; }
        public string UrlLogo { get; private set; }
        public List<Compte> ListeDesComptes { get; private set; }

        public Banque(string nom, string urlSite, string urlLogo)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
        }

        private AjouterCompte(Compte compte)
        {
            ListeDesComptes.Add(compte);
        }

        private SupprimerCompte(Compte compte)
        {
            foreach Compte in ListeDesComptes
            {
                if (compte.nom == ListeDesComptes.Compte.nom)
                    ListeDesComptes.Compte.Remove(ListeDesComptes);
            }

        }
    }
}
