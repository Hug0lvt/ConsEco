using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistanceManager
    {
        IEnumerable<Inscrit> LoadInscrit();
        IEnumerable<Banque> LoadBanque();
        void SupprimerInscritBdd(Inscrit inscrit);
        void SupprimerBanqueBdd(Inscrit inscrit, Banque banque);
        void SupprimerToutesBanquesBdd(Inscrit inscrit);
    }
}
