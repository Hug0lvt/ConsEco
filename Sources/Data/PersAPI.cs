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
        public async Task<bool> SupprimerInscrit(Inscrit inscrit)
        {
            return await ClientAPI.DeleteInscritAsync(inscrit.Mail);
        }
        public async Task<bool> ModifierMdpInscrit(string mail, string nouveauMdp)
        {
            return await ClientAPI.PutPasswordInscritAsync(mail, nouveauMdp);
        }
        public async Task<Inscrit> RecupererInscrit(string mail)
        {
            List<Inscrit> inscrits = await ClientAPI.GetInscritAsync(mail);
            if (inscrits.Count == 1)
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
        public async Task<bool> AjouterBanque(Banque banque, Inscrit inscrit)
        {
            return await ClientAPI.PostAddBanqueInscritAsync(banque.Nom, inscrit.Id.ToString());
        }
        public async Task<bool> SupprimerBanque(Banque banque, Inscrit inscrit)
        {
            return await ClientAPI.DeleteBanqueInscritAsync(banque.Nom, inscrit.Id.ToString());
        }
        public async Task<IList<BanqueInscrit>> RecupererBanques(Inscrit inscrit)
        {
            return await ClientAPI.GetBanqueAsync(inscrit.Id.ToString());
        }
        public async Task<IList<Banque>> RecupererBanquesDisponible()
        {
            return await ClientAPI.GetBanquesAsync();
        }


        //actions sur les comptes
        public async Task<bool> AjouterCompte(Compte compte, Inscrit inscrit)
        {
            return await ClientAPI.PostAddCompteInscritAsync(compte.Nom, inscrit.Id.ToString());
        }
        public async Task<bool> SupprimerCompte(Compte compte, Inscrit inscrit)
        {
            return await ClientAPI.DeleteCompteInscritAsync(compte.Nom, inscrit.Id.ToString());
        }
        public async Task<IList<Compte>> RecupererCompte(BanqueInscrit banque)
        {
            return await ClientAPI.GetCompteAsync(banque.Id.ToString());
        }


        //actions sur les Opérations
        public async Task<bool> AjouterOperation(Compte compte, Operation operation)
        {
            return await ClientAPI.PostAddOperationInscritAsync(compte, operation);
        }
        public async Task<bool> SupprimerOperation(Compte compte, Operation operation)
        {
            return await ClientAPI.DeleteOperationInscritAsync(compte.Identifiant, operation.Nom);
        }
        public async Task<IList<Operation>> RecupererOperation(Compte compte)
        {
            return await ClientAPI.GetOperationAsync(compte.Identifiant);
        }


        //actions sur les Planifications
        public async Task<bool> AjouterPlanification(Compte compte, Planification planification)
        {
            return await ClientAPI.PostAddPlanificationInscritAsync(compte, planification);
        }
        public async Task<bool> SupprimerPlanification(Compte compte, Planification planification)
        {
            return await ClientAPI.DeletePlanificationInscritAsync(compte.Identifiant, planification.Nom);
        }
        public async Task<IList<Planification>> RecupererPlanification(Compte compte)
        {
            return await ClientAPI.GetPlanificationAsync(compte.Identifiant);
        }

        //actions sur les Echéances
        public async Task<bool> AjouterEcheance(Compte compte, Echeance echeance)
        {
            return await ClientAPI.PostAddEcheanceInscritAsync(compte, echeance);
        }
        public async Task<bool> SupprimerEcheance(Compte compte, Echeance echeance)
        {
            return await ClientAPI.DeleteEcheanceInscritAsync(compte.Identifiant, echeance.IntituleOperation);
        }
        public async Task<IList<Echeance>> RecupererEcheance(Compte compte)
        {
            return await ClientAPI.GetEcheanceAsync(compte.Identifiant);
        }


        //actions utilitaire
        public async Task<bool> TestConnexion()
        {
            return await ClientAPI.GetStateApi();
        }

        public IList<Compte> GetDataFromOFX(string path)
        {
            return LoadOperation.LoadOperationsFromOFX(path);
        }
    }
}