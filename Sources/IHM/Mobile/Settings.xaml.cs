namespace IHM.Mobile;
using Model;
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
        await Navigation.PushModalAsync(new MainPage());
    }
}