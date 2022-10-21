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
    /// Logique d'interaction pour UCConnexion.xaml
    /// </summary>
    public partial class UCConnexion : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public UCConnexion()
        {
            InitializeComponent();
        }

        private void Button_Click_Acceuil(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_MAIN);
        }

        private void Button_Click_Connection(object sender, RoutedEventArgs e)
        {
            ErrorPassword.Visibility = Visibility.Hidden;
            Password.Background = new SolidColorBrush(Colors.White);
            ErrorUserName.Visibility = Visibility.Hidden;
            UserName.Background = new SolidColorBrush(Colors.White);
            if (UserName.Text.ToString() == "")
            {
                ErrorUserName.Visibility = Visibility.Visible;
                UserName.Background = new BrushConverter().ConvertFromString("#FF6347") as SolidColorBrush;
            }
            if (Password.Password.ToString() == "")
            {
                ErrorPassword.Visibility = Visibility.Visible;
                Password.Background = new BrushConverter().ConvertFromString("#FF6347") as SolidColorBrush;
            }
        }

        private void Button_Click_Forget_Password(object sender, RoutedEventArgs e)
        {
            // TO DO
        }

    }
}
