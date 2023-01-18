using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistanceManager
    {
        //   /!\ Toutes les méthodes ici permettent d'uniquement manipuler une stratégie de persistance
        //   /!\ et ne doit en aucun cas manipuler la mémoire !

        //actions sur les inscrits
        Task<bool> AjouterInscrit(Inscrit inscrit);
        Task<bool> SupprimerInscrit(Inscrit inscrit);
        Task<bool> ModifierMdpInscrit(string mail, string nouveauMdp);
        Task<Inscrit> RecupererInscrit(string mail);
        Task<bool> EmailDisponible(string mail);


        //actions sur les banques
        Task<bool> AjouterBanque(Banque banque, Inscrit inscrit);
        Task<bool> SupprimerBanque(Banque banque, Inscrit inscrit);
        Task<IList<BanqueInscrit>> RecupererBanques(Inscrit inscrit);
        Task<IList<Banque>> RecupererBanquesDisponible();


        //actions sur les comptes
        Task<bool> AjouterCompte(Compte compte, Inscrit inscrit);
        Task<bool> SupprimerCompte(Compte compte, Inscrit inscrit);
        Task<IList<Compte>> RecupererCompte(BanqueInscrit banque);


        //actions sur les Opérations
        Task<bool> AjouterOperation(Compte compte, Operation operation);
        Task<bool> SupprimerOperation(Compte compte, Operation operation);
        Task<IList<Operation>> RecupererOperation(Compte compte);


        //actions sur les Planifications
        Task<bool> AjouterPlanification(Compte compte, Planification planification);
        Task<bool> SupprimerPlanification(Compte compte, Planification planification);
        Task<IList<Planification>> RecupererPlanification(Compte compte);


        //actions sur les Echéances
        Task<bool> AjouterEcheance(Compte compte, Echeance echeance);
        Task<bool> SupprimerEcheance(Compte compte, Echeance echeance);
        Task<IList<Echeance>> RecupererEcheance(Compte compte);


        //actions utilitaire
        Task<bool> TestConnexion();
        IList<Compte> GetDataFromOFX(string path);

    }
}
