using Model;

namespace IHM.Desktop;

public partial class Echeancier : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public Echeancier()
	{
		InitializeComponent();

      /*  Mgr.LoadBanque();
        Mgr.LoadCompte();*/

        BindingContext = Mgr;

    }

	private void SaveEcheance_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_EnregistrerEcheance();
	}

	private void DelEcheance_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_SupprimerEcheance();
	}
}