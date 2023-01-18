using Model;

namespace IHM.Desktop;

public partial class Compte : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public Compte()
	{
		InitializeComponent();



        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;


    }

	private void AddCredit_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_modificationSolde();

    }
}