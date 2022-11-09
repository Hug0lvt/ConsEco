using LinqToPgSQL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class TestUnitPgSQL
    {
        [Fact]
        public void testLoadInscrit()
        {
            Manager m = new Manager(new PersLinqToPgSQL());
            //Assert.Null(m.SelectedBanque);
            //m.LoadInscrit("lucasevard@gmail.com", "test");
            //Assert.Equal(m.SelectedInscrits, "00001");
        }

    }
}
