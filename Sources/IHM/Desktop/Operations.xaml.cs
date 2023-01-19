using Model;

namespace IHM.Desktop;

public partial class Operations : ContentView
{

    public Manager Mgr => (App.Current as App).Manager;
    public Operations()
	{
		InitializeComponent();

        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;
	}

	private void AddCredit_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_credit();

    }

	private void RetireOperation_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_retirer();
    }

	private void AddDebit_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_debit();
    }

	private void DelOperation_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_supprimerOp();

    }
}