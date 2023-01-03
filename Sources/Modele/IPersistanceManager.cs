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
        bool AjouterInscrit(Inscrit inscrit);
        bool SupprimerInscrit(Inscrit inscrit);
        bool ModifierMdpInscrit(string mail, string nouveauMdp);
        Inscrit RecupererInscrit(string mail);
        bool EmailDisponible(string mail);


        //actions sur les banques
        bool AjouterBanque(Banque banque, Inscrit inscrit);
        bool SupprimerBanque(Banque banque, Inscrit inscrit);
        IList<Banque> RecupererBanques(Inscrit inscrit);
        IList<Banque> RecupererBanquesDisponible();


        //actions sur les comptes
        bool AjouterCompte(Compte compte);
        bool SupprimerCompte(Compte compte);
        bool ModifierCompte(Compte compte);
        IList<Compte> RecupererCompte(Banque banque);


        //actions sur les Opérations
        bool AjouterOperation(Compte compte);
        bool SupprimerOperation(Compte compte);
        bool ModifierOperation(Compte compte);
        IList<Compte> RecupererOperation(Compte compte);


        //actions sur les Planifications
        bool AjouterPlanification(Compte compte);
        bool SupprimerPlanification(Compte compte);
        bool ModifierPlanification(Compte compte);
        IList<Compte> RecupererPlanification(Compte compte);


        //actions sur les Echéances
        bool AjouterEcheance(Compte compte);
        bool SupprimerEcheance(Compte compte);
        bool ModifierEcheance(Compte compte);
        IList<Compte> RecupererEcheance(Compte compte);


        //actions utilitaire
        bool TestConnexion();

    }
}
