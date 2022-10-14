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
    }
}
