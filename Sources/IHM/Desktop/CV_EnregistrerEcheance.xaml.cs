

using Model;

namespace IHM.Desktop;

public partial class CV_EnregistrerEcheance : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_EnregistrerEcheance()
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
        Echeance ech = (Echeance)s;
        Operation operation = new Operation(ech.Nom, ech.Montant, ech.DateOperation, ech.ModePayement,ech.Tag,ech.IsDebit);

        Mgr.effectuerOperation(Mgr.SelectedCompte, operation);
        Mgr.supprimerEcheance(Mgr.SelectedCompte, ech);
        Thread.Sleep(1000);
    }
}