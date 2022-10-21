using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestsUnitaires
{
    public class TestUnitCompte
    {

        [Fact]
        public void TestConstructeurCompte()
        {
            Compte c1 = new("Livret A", 234);
            Compte c2 = new("&e23R_te7", 1245.34);
            Assert.Equal("Livret A", c1.Nom);
            Assert.Equal("&e23R_te7", c2.Nom);
            Assert.Equal(234, c1.Solde);
            Assert.Equal(1245.34, c2.Solde);
        }

        [Fact]
        public void testSupprimerBanque()
        {
            Banque bq = new Banque("Crédit Agricole", "https://creditagricole.fr", "https://yt3.ggpht.com/a/AGF-l7_mEfX2eQaGm8GefLOg5ZMRciNw-pESE3gUWg=s900-c-k-c0xffffffff-no-rj-mo");
            Inscrit i1 = new Inscrit("A1001", "Smith", "smith@gmail.com", "luke", "test20000aA", 500);
            Assert.NotNull(i1.LesBanques);
            i1.ajouterBanque(bq);
            Assert.Contains(bq, i1.LesBanques);
            i1.SupprimerBanque(bq);
            Assert.DoesNotContain(bq, i1.LesBanques);
        }
    }
}
