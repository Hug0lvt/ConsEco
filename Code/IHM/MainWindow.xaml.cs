﻿using System;
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

        public void testSelect()
        {
            foreach (Inscrit i in ListedesInscrits.ListedesInscrits)
            {
                
                
                 MessageBox.Show($"{i.Id} + {i.Nom} + {i.Prenom} + {i.Mail} + {i.Mdp}");
                
                
            }
            
        }

        public void testSuppression()
        {
            foreach (Inscrit i in ListedesInscrits.ListedesInscrits)
            {
                if (i.Nom == "YOUVOI")
                {
                    ListedesInscrits.supprimerInscritBdd(i);
                }

            }
            MessageBox.Show("Suppression ok");
        }

        public void testSupressionBdd(Banque b)
        {
           
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            testSelect(); 
   /*         testSuppression();*/
        }

    }
}
