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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour UCAjouterCompte.xaml
    /// </summary>
    public partial class UCAjouterCompte : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;

        public UCAjouterCompte()
        {
            InitializeComponent();
        }

        private void Button_Click_Retour(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_COMPTE);
        }
    }
}
