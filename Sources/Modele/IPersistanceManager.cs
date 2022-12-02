using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistanceManager
    {
        string GetId(string mail);
        void SupprimerInscritBdd(Inscrit inscrit);
        void SupprimerBanqueBdd(Inscrit inscrit, Banque banque);
        void SupprimerToutesBanquesBdd(Inscrit inscrit);
        void CreateInscrit(Inscrit inscrit);
        string LastInscrit();
        bool ExistEmail(string mail);
        void ChangePasswordBdd(string mail, string newMdp);
        string RecupMdpBdd(string mail);
        int CalculTotalSoldeComtpe(Inscrit user);
        List<Banque> LoadBanqueId(string id);
    }
}
