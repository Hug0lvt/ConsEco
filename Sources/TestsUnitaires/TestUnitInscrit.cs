using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TestsUnitaires
{
    public class TestUnitInscrit
    {
        [Fact]
        public void testCtorInscrit()
        {
            Inscrit i = new Inscrit(1, "LIVET", "Hugo.LIVET@etu.uca.fr", "Hugo", "Tu Sauras Passss:)1215", 2000);
            Assert.NotNull(i);
            Assert.Equal(1, i.Id);
            Assert.Equal("LIVET", i.Nom);
            Assert.Equal("Hugo.LIVET@etu.uca.fr", i.Mail);
            Assert.Equal("Hugo", i.Prenom);
            Assert.Equal("Tu Sauras Passss:)1215", i.Mdp);
            Assert.Equal(2000, i.SoldeTotal);
        }

        [Fact]
        public void testCtorInscrit2()
        {
            List<Banque> lesBanques = new List<Banque>();
            Banque b = new Banque("CA", "enavantouioui.fr", "NaN.fr");
            lesBanques.Add(b);
            Inscrit i = new Inscrit(1, "LIVET", "Hugo.LIVET@etu.uca.fr", "Hugo", "Tu Sauras Passss:)1215", 2000, lesBanques);
            Assert.NotNull(i);
            Assert.Equal(1, i.Id);
            Assert.Equal("LIVET", i.Nom);
            Assert.Equal("Hugo.LIVET@etu.uca.fr", i.Mail);
            Assert.Equal("Hugo", i.Prenom);
            Assert.Equal("Tu Sauras Passss:)1215", i.Mdp);
            Assert.Equal(2000, i.SoldeTotal);
            Assert.Contains(b, i.LesBanques);
            lesBanques.Remove(b);
            Assert.DoesNotContain(b, i.LesBanques);
        }

        [Fact]
        public void testAjoutBanqueInscrit()
        {
            Banque b = new Banque("CA", "enavantouioui.fr", "NaN.fr");
            Inscrit i = new Inscrit(1, "LIVET", "Hugo.LIVET@etu.uca.fr", "Hugo", "Tu Sauras Passss:)1215", 2000);
            i.ajouterBanque(b);
            Assert.Contains(b, i.LesBanques);
        }

        [Fact]
        public void testSupprimerBanqueInscrit()
        {
            Banque b = new Banque("CA", "enavantouioui.fr", "NaN.fr");
            Inscrit i = new Inscrit(1, "LIVET", "Hugo.LIVET@etu.uca.fr", "Hugo", "Tu Sauras Passss:)1215", 2000);
            i.ajouterBanque(b);
            i.SupprimerBanque(b);
            Assert.DoesNotContain(b, i.LesBanques);
            i.ajouterBanque(new Banque("CA", "enavantouioui.fr", "NaN.fr"));
            i.SupprimerBanque(new Banque("CA", "enavantouioui.fr", "NaN.fr"));
            Assert.DoesNotContain(new Banque("CA", "enavantouioui.fr", "NaN.fr"), i.LesBanques);
        }

        [Fact]
        public void testChoixDeviseInscrit()
        {
            Inscrit i = new Inscrit(1, "LIVET", "Hugo.LIVET@etu.uca.fr", "Hugo", "Tu Sauras Passss:)1215", 2000);
            i.ChoisirDevise(Devises.Euro);
            Assert.Equal(Devises.Euro, i.Dev);
        }

        [Theory]
        [InlineData(1, "LIVET", "a@a.fr", "Hugo", "123Soleil@azerty", 20000, true)]//OK
        [InlineData(2, "LIVET", "aa.fr", "Hugo", "123Soleil@azerty", 20000, false)]//Mail invalide psk pas de @
        [InlineData(3, "LIVET", "a@a.fr", "Hugo", "123soleil@azerty", 20000, false)]//mdp Invalide psk mdp sans Maj
        [InlineData(4, "LIVET", "a@a.fr", "Hugo", "Soleil@azerty", 20000, false)]//mdp Invalide psk pas de chiffres
        public void CtorInscrit2TU(int id, string nom, string mail, string prenom, string mdp, double solde, bool notShouldThrowException)
        {
            if (!notShouldThrowException)
            {
                Assert.ThrowsAny<ArgumentException>(() => new Inscrit(id, nom, mail, prenom, mdp, solde));
                return;
            }
            Inscrit i = new Inscrit(id, nom, mail, prenom, mdp, solde);
            Assert.NotNull(i);
            Assert.Equal(id, i.Id);
            Assert.Equal(nom, i.Nom);
            Assert.Equal(mail, i.Mail);
            Assert.Equal(prenom, i.Prenom);
            Assert.Equal(mdp, i.Mdp);
            Assert.Equal(solde, i.SoldeTotal);
        }
    }
}
