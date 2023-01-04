using Model;

namespace IHM.Desktop;

public partial class Operations : ContentView
{


	List<Operation> operations;
    public Operations()
	{
		InitializeComponent();

        // Temporaire pour établir le binding de la vue
		operations = new List<Operation>();
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));
        operations.Add(new("course", "CB", "Alimentation", "12/12/2022", 22.45));
        operations.Add(new("essence", "cheque", "Carburant", "12/12/2022", 45.80));
        operations.Add(new("Orange", "Prelevement", "Facture", "12/12/2022", 48));

        BindingContext = operations;
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