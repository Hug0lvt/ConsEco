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

    public partial class UCCompte : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public UCCompte()
        {
            InitializeComponent();
        }
        private void Button_Click_ModifSolde(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_MODIFSOLDE);
        }

        private void Button_Click_Ajouter_Banque(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_AJOUTER_BANQUE);
        }

        private void Button_Click_Supprimer_Banque(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_SUPPRIMER_BANQUE);
        }

        private void Button_Click_Ajouter_Compte(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_AJOUTER_COMPTE);
        }

        private void Button_Click_Supprimer_Compte(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_SUPPRIMER_COMPTE);
        }
    }

}
