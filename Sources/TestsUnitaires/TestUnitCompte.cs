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
            Compte c1 = new("012345678901", "Livret A", 234);
            Compte c2 = new("012345678902", "&e23R_te7", 1245.34);
            Assert.Equal("Livret A", c1.Nom);
            Assert.Equal("&e23R_te7", c2.Nom);
            Assert.Equal(234, c1.Solde);
            Assert.Equal(1245.34, c2.Solde);
        }

        [Fact]
        public void TestConstructeurCompte2()
        {
            List<Operation> testlistope = new();
            Operation testope = new("test", 20, DateTime.Now, MethodePayement.CB, TagOperation.Alimentaire, true, true);
            testlistope.Add(testope);
            Compte c1 = new("012345678901", "Livret A", 234,testlistope);
            Compte c2 = new("012345678902", "&e23R_te7", 1245.34, testlistope);
            Assert.Equal("Livret A", c1.Nom);
            Assert.Equal("&e23R_te7", c2.Nom);
            Assert.Equal(234, c1.Solde);
            Assert.Equal(1245.34, c2.Solde);
            Assert.NotNull(testlistope);
            Assert.NotNull(testope);
            Assert.True(c1.LesOpe.Count() == 1);
            Assert.True(c2.LesOpe.Count() == 1);
            c1.supprimerOperation(testope);
            c2.supprimerOperation(testope);
            Assert.True(c1.LesOpe.Count() == 0);
            Assert.True(c2.LesOpe.Count() == 0);
        }


        [Fact]
        public void testAjouterOperation()
        {
            Compte c1 = new("012345678901", "Livret A", 234);
            c1.ajouterOperation(new("test", 20, DateTime.Now, MethodePayement.CB, TagOperation.Alimentaire, true, true));
            Assert.True(c1.LesOpe.Count() == 1);
        }

        [Fact]
        public void testSupprimerOperation()
        {
            Compte c1 = new("012345678901", "Livret A", 234);
            Operation testope = new("test", 20, DateTime.Now, MethodePayement.CB, TagOperation.Alimentaire, true, true);
            c1.ajouterOperation(testope);
            Assert.True(c1.LesOpe.Count() == 1);
            c1.supprimerOperation(testope);
            Assert.True(c1.LesOpe.Count() == 0);
        }


        [Fact]
        public void testSupprimerBanque()
        {
            Banque bq = new Banque("Crédit Agricole", "https://creditagricole.fr", "https://yt3.ggpht.com/a/AGF-l7_mEfX2eQaGm8GefLOg5ZMRciNw-pESE3gUWg=s900-c-k-c0xffffffff-no-rj-mo");
            Inscrit i1 = new Inscrit(1, "Smith", "smith@gmail.com", "luke", "test20000aA", 500);
            Assert.NotNull(i1.LesBanques);
            i1.ajouterBanque(bq);
            Assert.Contains(bq, i1.LesBanques);
            i1.SupprimerBanque(bq);
            Assert.DoesNotContain(bq, i1.LesBanques);
        }
   



    }
}
