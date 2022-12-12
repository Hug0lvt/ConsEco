namespace IHM.Mobile;
using Model;
using System.Diagnostics;

public partial class Settings : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public Settings()
	{
		InitializeComponent();
	}
	public void deconnexionOnClicked(object sender, EventArgs e)
	{
        Mgr.deconnexion();
        NavigateTo();
    }
    private async void NavigateTo()
    {
        await Navigation.PushModalAsync(new MainPage());
    }

}