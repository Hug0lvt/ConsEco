using IHM.Desktop;
using IHM.Mobile;
using Model;
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
        }

    }
}