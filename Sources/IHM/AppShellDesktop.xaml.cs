using IHM.Desktop;
using Model;

namespace IHM
{
    public partial class AppShellDesktop : Shell
    {
        public Manager Mgr => (App.Current as App).Manager;

        public AppShellDesktop()
        {
            InitializeComponent();
        }

 
           
        
    }
}