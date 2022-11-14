namespace IHM;

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
		Mgr.SelectedInscrit = null;
        NavigateTo();
    }
    private async void NavigateTo()
    {
        OnBackButtonPressed();
        Debug.WriteLine(base.OnBackButtonPressed());
        await Navigation.PushModalAsync(new MainPage());
    }

}