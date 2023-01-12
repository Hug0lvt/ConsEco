using Model;

namespace IHM.Desktop;

public partial class Compte : ContentView
{
	
    public Compte()
	{
		InitializeComponent();

		Model.Compte compte = new Model.Compte("", "Compte courant", 2000);

		BindingContext = compte;
		
		
	}

	private void AddCredit_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_modificationSolde();

    }
}