using Model;

namespace IHM.Desktop;

public partial class CV_DeletePlanification : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_DeletePlanification()
	{
		InitializeComponent();
        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;
    }

	private void Button_Annuler(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Dashboard());
    }

	private void Button_Valider(object sender, EventArgs e)
	{
        var s = recup.SelectedItem;
        Model.Planification planification = (Model.Planification)s;
        Mgr.supprimerPlanification(Mgr.SelectedCompte, planification);
        Navigation.PushAsync(new Dashboard());
    }
}