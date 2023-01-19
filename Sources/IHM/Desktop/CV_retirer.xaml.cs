using Model;

namespace IHM.Desktop;

public partial class CV_retirer : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_retirer()
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
        Operation operation = (Operation)s;
        Mgr.supprimerOperation(Mgr.SelectedCompte, operation);
        Navigation.PushAsync(new Dashboard());

    }
}