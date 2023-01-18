using Model;

namespace IHM.Desktop;

public partial class CV_SupprimerEcheance : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    
	public CV_SupprimerEcheance()
	{
		InitializeComponent();


        

        BindingContext = Mgr;
    }

	private void Button_Clicked(object sender, EventArgs e)
	{

	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{

	}
}