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
        public Manager Manager => ((App)Application.Current).Manager;
   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Manager.SelectedInscrits;
        }

        public void testSelect()
        {
                 MessageBox.Show($"{Manager.SelectedInscrits}");
        }

        public void testSuppression()
        {
            MessageBox.Show("Suppression ok");
        }

        public void testSupressionBanqueBdd()
        {
            foreach (Inscrit i in ListedesInscrits.ListedesInscrits)
            {
                if(i.Id == "00001")
                {
                    MessageBox.Show("Suppression ok");
                    Banque b = new Banque("BNP PARIBAS", "mabanque", "bite");
                    ListedesInscrits.supprimerBanqueBdd(i, b);
                    MessageBox.Show("Suppression ok");
                }
            }
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Manager.LoadInscrit(id.Text,mdp.Text);
            if (Manager.SelectedInscrits != null)
            {
                idpers.Text = Manager.SelectedInscrits;
                testSelect();
            }
            else idpers.Text = "";
        }

    }
}
