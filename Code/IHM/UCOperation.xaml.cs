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
    /// Logique d'interaction pour UCOperation.xaml
    /// </summary>
    public partial class UCOperation : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;

        public UCOperation()
        {
            InitializeComponent();
        }
        private void Button_Click_EffectuerCredit(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_EFFECTUER_CREDIT);
        }
        private void Button_Click_EffectuerDebit(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_EFFECTUER_DEBIT);
        }
        private void Button_Click_RetirerOperation(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_RETIRER_OPERATION);
        }
        private void Button_Click_SupprimerOperation(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_SUPPRIMER_OPERATION);
        }
    }
}
