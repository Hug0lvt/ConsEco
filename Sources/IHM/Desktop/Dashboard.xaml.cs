using Microsoft.Maui.Graphics.Text;

namespace IHM.Desktop;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

	private void Button_planification(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Planification());
    }

	private void Button_echeancier(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Echeancier());
    }

	private void Button_operation(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Operations());
    }

	private void Button_compte(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Compte());
    }

}