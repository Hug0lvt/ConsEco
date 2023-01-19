using Model;

namespace IHM.Desktop;

public partial class CV_supprimerOp : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_supprimerOp()
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
        Operation operation = (Operation)s;
        Mgr.supprimerOperation(Mgr.SelectedCompte,operation);
    }
}