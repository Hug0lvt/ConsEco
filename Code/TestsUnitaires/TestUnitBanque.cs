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
        Compte tc = new("Livret A", 16956);
        Banque test = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png");
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
            listeCompte.Add(tc);
            Banque test2 = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", listeCompte);
            Assert.NotNull(test);
            Assert.NotNull(test.ListeDesComptes);
            Assert.Equal("BNP Paribas", test.Nom);
            Assert.NotEqual("https://mabanque.bnpparibas/", test.Nom);
            Assert.Equal("https://mabanque.bnpparibas/", test.UrlSite);
            Assert.Equal("https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", test.UrlLogo);
            Assert.Contains(tc,test2.ListeDesComptes);
        }
        [Fact]
        public void testAjouterCompte()
        {
            Assert.NotNull(test.ListeDesComptes);
            test.AjouterCompte(tc);
            Assert.Contains(tc, test.ListeDesComptes);
        }
        [Fact]
        public void testSupprimerCompte()
        {
            Assert.NotNull(test.ListeDesComptes);
            test.AjouterCompte(tc);
            Assert.Contains(tc, test.ListeDesComptes);
            test.SupprimerCompte(tc);
            Assert.DoesNotContain(tc, test.ListeDesComptes);
        }
        [Fact]
        public void testExisteCompte()
        {
            List<Compte> listeCompte = new();
            listeCompte.Add(tc);
            Banque test2 = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", listeCompte);
            Assert.True(test2.ExisteCompte("Livret A"));
        }
        [Fact]
        public void testReturnCompte()
        {
            List<Compte> listeCompte = new();
            listeCompte.Add(tc);
            Banque test2 = new("BNP Paribas", "https://mabanque.bnpparibas/", "https://logos-marques.com/wp-content/uploads/2020/12/BNP-Paribas-logo.png", listeCompte);
            Assert.True(test2.ExisteCompte("Livret A"));
            Assert.Equal(tc, test2.ReturnCompte("Livret A"));
        }

    
    }
}