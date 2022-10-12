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

        public Banque(string nom, string urlSite, string urlLogo, List<Compte>lescomptes)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
            ListeDesComptes = lescomptes;
        }

        private void AjouterCompte(Compte compte)
        {
            ListeDesComptes.Add(compte);
        }

        private void SupprimerCompte(Compte compte)
        {
            ListeDesComptes.Remove(compte);
        }
    }
}
