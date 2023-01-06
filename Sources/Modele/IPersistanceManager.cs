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
        bool SupprimerInscrit(Inscrit inscrit);
        bool ModifierMdpInscrit(string mail, string nouveauMdp);
        Inscrit RecupererInscrit(string mail);
        Task<bool> EmailDisponible(string mail);


        //actions sur les banques
        bool AjouterBanque(Banque banque, Inscrit inscrit);
        bool SupprimerBanque(Banque banque, Inscrit inscrit);
        IList<Banque> RecupererBanques(Inscrit inscrit);
        IList<Banque> RecupererBanquesDisponible();


        //actions sur les comptes
        bool AjouterCompte(Compte compte, Inscrit inscrit);
        bool SupprimerCompte(Compte compte, Inscrit inscrit);
        IList<Compte> RecupererCompte(Banque banque, Inscrit inscrit);


        //actions sur les Opérations
        bool AjouterOperation(Compte compte, Operation operation);
        bool SupprimerOperation(Compte compte, Operation operation);
        IList<Operation> RecupererOperation(Compte compte);


        //actions sur les Planifications
        bool AjouterPlanification(Compte compte, Planification planification);
        bool SupprimerPlanification(Compte compte, Planification planification);
        IList<Planification> RecupererPlanification(Compte compte);


        //actions sur les Echéances
        bool AjouterEcheance(Compte compte, Echeance echeance);
        bool SupprimerEcheance(Compte compte, Echeance echeance);
        IList<Echeance> RecupererEcheance(Compte compte);


        //actions utilitaire
        bool TestConnexion();
        IList<Compte> GetDataFromOFX(string path);

    }
}
