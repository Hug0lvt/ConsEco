using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistanceManager
    {
        Inscrit LoadInscrit();
        void SupprimerInscritBdd(Inscrit inscrit);
    }
}
