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
    /// Logique d'interaction pour UCPlannification.xaml
    /// </summary>
    public partial class UCPlanification : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;

        public UCPlanification()
        {
            InitializeComponent();
        }

        private void Button_Click_Ajouter_Planification(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_AJOUTER_PLANIFICATION);
        }

        private void Button_Click_Supprimer_Planification(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_SUPPRIMER_PLANIFICATION);
        }
    }
}
