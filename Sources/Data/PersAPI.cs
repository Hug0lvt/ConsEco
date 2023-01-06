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
        public async Task<bool> AjouterInscrit(Inscrit inscrit)
        {
            return await ClientAPI.PostAddInscritAsync(inscrit.Nom, inscrit.Prenom, inscrit.Mail, inscrit.Mdp);
            
        }
        public bool SupprimerInscrit(Inscrit inscrit)
        {
            return ClientAPI.DeleteInscritAsync(inscrit.Mail).GetAwaiter().GetResult();
        }
        public bool ModifierMdpInscrit(string mail, string nouveauMdp)
        {
            return ClientAPI.PutPasswordInscritAsync(mail,nouveauMdp).GetAwaiter().GetResult();
        }
        public async Task<Inscrit> RecupererInscrit(string mail)
        {
            List<Inscrit> inscrits = await ClientAPI.GetInscritAsync(mail);
            if(inscrits.Count == 1)
            {
                return inscrits.First();
            }
            throw new ArgumentException("Cet email a un problème");

        }
        public async Task<bool> EmailDisponible(string mail)
        {
            List<Inscrit> inscrits = await ClientAPI.GetInscritAsync(mail);
            if (inscrits.Count >= 1)
            {
                return true;
            }
            return false;
        }


        //actions sur les banques
        public bool AjouterBanque(Banque banque, Inscrit inscrit)
        {
            return ClientAPI.PostAddBanqueInscritAsync(banque.Nom, inscrit.Id.ToString()).GetAwaiter().GetResult();
        }
        public bool SupprimerBanque(Banque banque, Inscrit inscrit)
        {
            return ClientAPI.DeleteBanqueInscritAsync(banque.Nom, inscrit.Id.ToString()).GetAwaiter().GetResult();
        }
        public IList<Banque> RecupererBanques(Inscrit inscrit)
        {
            return ClientAPI.GetBanqueAsync(inscrit.Id.ToString()).GetAwaiter().GetResult();
        }
        public IList<Banque> RecupererBanquesDisponible()
        {
            return ClientAPI.GetBanquesAsync().GetAwaiter().GetResult();
        }


        //actions sur les comptes
        public bool AjouterCompte(Compte compte, Inscrit inscrit)
        {
            return ClientAPI.PostAddCompteInscritAsync(compte.Nom, inscrit.Id.ToString()).GetAwaiter().GetResult();
        }
        public bool SupprimerCompte(Compte compte, Inscrit inscrit)
        {
            return ClientAPI.DeleteCompteInscritAsync(compte.Nom, inscrit.Id.ToString()).GetAwaiter().GetResult();
        }
        public IList<Compte> RecupererCompte(Banque banque, Inscrit inscrit)
        {
            return ClientAPI.GetCompteAsync(inscrit.Id.ToString()).GetAwaiter().GetResult();
        }


        //actions sur les Opérations
        public bool AjouterOperation(Compte compte, Operation operation)
        {
            return ClientAPI.PostAddOperationInscritAsync(compte,operation).GetAwaiter().GetResult();
        }
        public bool SupprimerOperation(Compte compte, Operation operation)
        {
            return ClientAPI.DeleteOperationInscritAsync(compte.Identifiant, operation.IntituleOperation).GetAwaiter().GetResult();
        }
        public IList<Operation> RecupererOperation(Compte compte)
        {
            return ClientAPI.GetOperationAsync(compte.Identifiant).GetAwaiter().GetResult();
        }


        //actions sur les Planifications
        public bool AjouterPlanification(Compte compte, Planification planification)
        {
            return ClientAPI.PostAddPlanificationInscritAsync(compte, planification).GetAwaiter().GetResult();
        }
        public bool SupprimerPlanification(Compte compte, Planification planification)
        {
            return ClientAPI.DeletePlanificationInscritAsync(compte.Identifiant, planification.IntituleOperation).GetAwaiter().GetResult();
        }
        public IList<Planification> RecupererPlanification(Compte compte)
        {
            return ClientAPI.GetPlanificationAsync(compte.Identifiant).GetAwaiter().GetResult();
        }


        //actions sur les Echéances
        public bool AjouterEcheance(Compte compte, Echeance echeance)
        {
            return ClientAPI.PostAddEcheanceInscritAsync(compte, echeance).GetAwaiter().GetResult();
        }
        public bool SupprimerEcheance(Compte compte, Echeance echeance)
        {
            return ClientAPI.DeleteEcheanceInscritAsync(compte.Identifiant, echeance.IntituleOperation).GetAwaiter().GetResult();
        }
        public IList<Echeance> RecupererEcheance(Compte compte)
        {
            return ClientAPI.GetEcheanceAsync(compte.Identifiant).GetAwaiter().GetResult();
        }


        //actions utilitaire
        public bool TestConnexion()
        {
            return ClientAPI.GetStateApi().GetAwaiter().GetResult();
        }

        public IList<Compte> GetDataFromOFX(string path)
        {
            return LoadOperation.LoadOperationsFromOFX(path);
        }
    }
}