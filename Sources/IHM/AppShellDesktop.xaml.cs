using IHM.Desktop;
using IHM.Mobile;
using Model;
using ChangePassword = IHM.Desktop.ChangePassword;
using Compte = IHM.Desktop.Compte;
using ForgetPassword = IHM.Desktop.ForgetPassword;

namespace IHM
{
    public partial class AppShellDesktop : Shell
    {
        public Manager Mgr => (App.Current as App).Manager;
        


        public AppShellDesktop()
        {
            InitializeComponent();
            Routing.RegisterRoute("ForgetPassword", typeof(ForgetPassword));
            Routing.RegisterRoute("ChangePassword", typeof(ChangePassword));
            Routing.RegisterRoute("Compte", typeof(Compte));

        }

    }
}