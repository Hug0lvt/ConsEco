
using Model;

namespace IHM.Desktop;

public partial class CV_SupprimerEcheance : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    
	public CV_SupprimerEcheance()
	{
		InitializeComponent();


        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;
    }

	private void Button_Annuler(object sender, EventArgs e)
	{

	}

	private void Button_Valider(object sender, EventArgs e)
	{
		var s = recup.SelectedItem;
		Echeance echeance = (Echeance)s;
		Mgr.supprimerEcheance(Mgr.SelectedCompte, echeance);
		
	}
}