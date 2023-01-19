namespace IHM.Desktop;

public partial class CV_modificationSolde : ContentView
{
	public CV_modificationSolde()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Dashboard());
    }

	private void Button_Clicked_1(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Dashboard());
    }
}