using Microsoft.Maui.Graphics.Text;

namespace IHM.Desktop;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Planification());
    }
}