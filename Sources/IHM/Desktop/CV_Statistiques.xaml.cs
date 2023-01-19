namespace IHM.Desktop;
using Model;

public partial class CV_Statistiques : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_Statistiques()
	{
		InitializeComponent();

        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;
    }
}