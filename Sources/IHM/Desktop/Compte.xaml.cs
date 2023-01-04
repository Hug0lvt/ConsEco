namespace IHM.Desktop;

public partial class Compte : ContentView
{
	public Compte()
	{
		InitializeComponent();

	}

	private void AddCredit_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_modificationSolde();

    }
}