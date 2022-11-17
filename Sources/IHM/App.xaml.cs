using LinqToPgSQL;
using Model;

namespace IHM
{
    public partial class App : Application
    {
        public Manager Manager { get; set; } = new Manager(new PersLinqToPgSQL());
        public App()
        {
            InitializeComponent();

            if(OperatingSystem.IsWindows() || OperatingSystem.IsMacOS())
            {
                MainPage = new AppShellDesktop();
            }
            else
            {
                MainPage = new AppShell();
            }
        }

    }
}