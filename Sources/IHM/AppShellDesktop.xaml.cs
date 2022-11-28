using IHM.Desktop;
using IHM.Mobile;
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