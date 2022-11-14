using Model;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;

namespace IHM;

public partial class DashBoard : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public DashBoard()
	{
		InitializeComponent();
        //Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));


        if (Mgr.SelectedInscrit == null)
        {
            loadInscription();
        }
    }

    async void OnClickedGestionBanque(object sender, EventArgs args)
    {
        Bouton.IsEnabled = false;
        Bouton.BackgroundColor = Color.FromRgb(192, 192, 192);
        await Bouton.TranslateTo(-130, 35, 50);
        await Bouton.ScaleXTo(7.5, 50);
        await Bouton.ScaleYTo(3, 50);
        BoutonRetour.IsVisible = true;
        ImgBanqueActuelle.IsVisible = true;

        //await Navigation.PushModalAsync(new GestionBanque());
    }

    async void OnClickedRetour(object sender, EventArgs args)
    {
        await Bouton.ScaleXTo(1, 50);
        await Bouton.ScaleYTo(1, 50);
        ImgBanqueActuelle.IsVisible = false;
        await Bouton.TranslateTo(0,0,50);
        BoutonRetour.IsVisible = false;
        Bouton.IsEnabled = true;
    }

    public async void loadInscription()
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}