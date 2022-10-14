using Model;

namespace TestsUnitaires
{
    public class TU_Compte
    {

        [Fact]
        public void Ctor_Compte()
        {
            Compte c = new Compte("Crédit Agricole", 20000);
            Assert.NotNull(c);
            Assert.Equal("Crédit Agricole", c.Nom);
            Assert.Equal(20000, c.Solde);
        }


        [Fact]
        public void testSupprimerBanque()
        {
            Banque bq = new Banque("Crédit Agricole", "https://creditagricole.fr", "https://yt3.ggpht.com/a/AGF-l7_mEfX2eQaGm8GefLOg5ZMRciNw-pESE3gUWg=s900-c-k-c0xffffffff-no-rj-mo");
            Inscrit i1 = new Inscrit("A1001", "Smith", "smith@gmail.com", "luke", "test", 500);
            Assert.NotNull(i1.LesBanques);
            i1.ajouterBanque(bq);
            Assert.Contains(bq, i1.LesBanques);
            i1.SupprimerBanque(bq);
            Assert.DoesNotContain(bq, i1.LesBanques);
            
        }

    }
}