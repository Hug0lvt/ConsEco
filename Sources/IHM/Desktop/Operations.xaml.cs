namespace IHM.Desktop;

public partial class Operations : ContentView
{
	public Operations()
	{
		InitializeComponent();
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