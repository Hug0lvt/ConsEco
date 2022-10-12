using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestsUnitaires
{
    public class TestUnitBanque
    {
        Banque test = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png");
        Banque test2 = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", listeCompte);

        [Fact]
        public void testConstructeur1()
        {
            Assert.NotNull(test);
            Assert.Equal("BNP Paribas", test.Nom);
            Assert.NotEqual("https://mabanque.bnpparibas/", test.Nom);
            Assert.Equal("https://mabanque.bnpparibas/", test.UrlSite);
            Assert.Equal("https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", test.UrlLogo);
        }
        [Fact]
        public void testConstructeur2()
        {
            List<Compte> listeCompte = new();
            Compte tc = new("Livret A", 16956);
            listeCompte.Add(tc);
            Assert.NotNull(test2);
            Assert.NotNull(test2.ListeDesComptes);
            Assert.Equal("BNP Paribas", test.Nom);
            Assert.NotEqual("https://mabanque.bnpparibas/", test2.Nom);
            Assert.Equal("https://mabanque.bnpparibas/", test2.UrlSite);
            Assert.Equal("https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", test2.UrlLogo);
            Assert.Contains(tc, test2.ListeDesComptes);
        }
        [Fact]
        public void testAjouterCompte()
        {
            Compte tc = new("Livret A", 16956);
            Assert.NotNull(test.ListeDesComptes);
            test.AjouterCompte(tc);
            Assert.Contains(tc, test.ListeDesComptes);
        }
        [Fact]
        public void testSupprimerCompte()
        {
            Compte tc = new("Livret A", 16956);
            Assert.NotNull(test.ListeDesComptes);
            test.AjouterCompte(tc);
            Assert.Contains(tc, test.ListeDesComptes);
            test.SupprimerCompte(tc);
            Assert.DoesNotContain(tc, test.ListeDesComptes);
        }

    }
}