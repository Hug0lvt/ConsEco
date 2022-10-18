using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void ChangerStyleBtn(Button btn)
        {

            StackPanel sp = (StackPanel)btn.Parent;
            if (sp == null) return;
            UIElementCollection UIEC = sp.Children;
            if (UIEC == null) return;
            foreach (UIElement obj in UIEC)
            {

                if (obj as Button != null)
                {
                    (obj as Button).IsDefault = false;
                }

            }
            btn.IsDefault = true;
        }

        private void Button_Click_TableauDeBord(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.IsDefault == false)
            {
                Nav.NavigateTo(Navigator.PART_TABLEAU_DE_BORD);
                ChangerStyleBtn(btn);


            }
            else return;

        }

        private void Button_Click_Compte(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.IsDefault == false)
            {
                
                Nav.NavigateTo(Navigator.PART_COMPTE);
                ChangerStyleBtn(btn);

            }
            else return;

        }

        private void Button_Click_Operation(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.IsDefault == false)
            {

                Nav.NavigateTo(Navigator.PART_OPERATION);
                ChangerStyleBtn(btn);

            }
            else return;

        }

        private void Button_Click_Echeancier(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.IsDefault == false)
            {

                Nav.NavigateTo(Navigator.PART_ECHEANCIER);
                ChangerStyleBtn(btn);

            }
            else return;

        }

        private void Button_Click_Plannification(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.IsDefault == false)
            {

                Nav.NavigateTo(Navigator.PART_PLANIFICATION);
                ChangerStyleBtn(btn);

            }
            else return;
        }

        
    }
}
