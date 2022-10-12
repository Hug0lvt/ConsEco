using Model;

namespace TestsUnitaires
{
    public class TU_Compte
    {
        [Fact]
        public void Ctor_Compte()
        {
            Compte c = new Compte("Cr�dit Agricole", 20000);
            Assert.NotNull(c);
            Assert.Equal("Cr�dit Agricole", c.Nom);
            Assert.Equal(20000, c.Solde);
        }
    }
}