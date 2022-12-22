using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersAPI : IPersistanceManager
    {
        //   /!\ Toutes les méthodes ici permettent d'uniquement manipuler une stratégie de persistance
        //   /!\ et ne doit en aucun cas manipuler la mémoire !

        //actions sur les inscrits
        public bool AjouterInscrit(Inscrit inscrit)
        {
            return ClientAPI.PostAddInscritAsync(inscrit.Nom, inscrit.Prenom, inscrit.Mail, inscrit.Mdp).GetAwaiter().GetResult();
        }
        public bool SupprimerInscrit(Inscrit inscrit)
        {
            throw new NotImplementedException();
        }
        public bool ModifierMdpInscrit(string mail, string nouveauMdp)
        {
            return ClientAPI.PutPasswordInscritAsync(mail,nouveauMdp).GetAwaiter().GetResult();
        }
        public Inscrit RecupererInscrit(string mail)
        {
            List<Inscrit> inscrits = ClientAPI.GetInscritAsync(mail).GetAwaiter().GetResult();
            if(inscrits.Count >= 1)
            {
                throw new ArgumentException("Cet email contient plusieurs utilisateurs pour la même adresse");
            }
            return inscrits.FirstOrDefault();
        }
        public bool EmailDisponible(string mail)
        {
            throw new NotImplementedException();
        }


        //actions sur les banques
        public bool AjouterBanque(Banque banque)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerBanque(Banque banque)
        {
            throw new NotImplementedException();
        }
        public bool ModifierBanque(Banque banque)
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


        //actions sur les comptes
        public bool AjouterCompte(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerCompte(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierCompte(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererCompte(Banque banque)
        {
            throw new NotImplementedException();
        }


        //actions sur les Opérations
        public bool AjouterOperation(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerOperation(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierOperation(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererOperation(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions sur les Planifications
        public bool AjouterPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererPlanification(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions sur les Echéances
        public bool AjouterEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool SupprimerEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public bool ModifierEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }
        public IList<Compte> RecupererEcheance(Compte compte)
        {
            throw new NotImplementedException();
        }


        //actions utilitaire
        public bool TestConnexion()
        {
            throw new NotImplementedException();
        }
    }
}