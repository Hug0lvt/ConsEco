using Model;

namespace IHM
{
    public partial class AppShell : Shell
    {
        public Manager Mgr => (App.Current as App).Manager;

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DashBoard", typeof(DashBoard));
            Routing.RegisterRoute("Inscription", typeof(Inscription));
            Routing.RegisterRoute("ForgetPassword", typeof(ForgetPassword));
            Routing.RegisterRoute("ChangePassword", typeof(ChangePassword));
        }
           
        
    }
}