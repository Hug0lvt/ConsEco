using Model;

namespace IHM.Desktop;

public partial class Operations : ContentView
{

   /* List<Operation> operations;*/
    public Manager Mgr => (App.Current as App).Manager;
    public Operations()
	{
		InitializeComponent();

        /*  operations = new List<Operation>();
          operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
          operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
          operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
          operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
          operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
          operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Carburant, true));

          BindingContext = operations;*/


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