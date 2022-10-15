using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LinqToPgSQL;
using Model;

namespace IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager ListedesInscrits => ((App)Application.Current).AllInscrits;
        public MainWindow()
        {
            InitializeComponent();

            ListedesInscrits.LoadInscrit();
            DataContext = ListedesInscrits;
            
        }

        public void test()
        {
            foreach (Inscrit i in ListedesInscrits.ListedesInscrits)
            {
                if(i.Nom == "YOUVOI")
                {
                   MessageBox.Show($"{i.Id} + {i.Nom} + {i.Mdp} + {i.Mail} + {i.Dev}");
                }
                
            }
            
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {

            test(); 
          



        }
    }
}
