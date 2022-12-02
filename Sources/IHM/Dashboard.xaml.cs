using Model;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;
using System.Diagnostics;

namespace IHM
{

    public partial class DashBoard : ContentPage
    {
        public Manager Mgr => (App.Current as App).Manager;
        public DashBoard()
        {
            InitializeComponent();
            BindingContext = Mgr;
            //Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));
            if (Mgr.User == null)
            {
                loadInscription();
            }
        }

        void OnClickedBanque(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            ImgBanqueActuelle.Text = btn.Text;
        }


        async void OnClickedGestionBanque(object sender, EventArgs args)
        {
            Bouton.BackgroundColor = Color.FromRgb(192, 192, 192);
            await Bouton.TranslateTo(-130, 35, 50);
            await Bouton.ScaleXTo(7.5, 50);
            await Bouton.ScaleYTo(3, 50);
            stackpannel.IsVisible = true;
            BoutonRetour.IsVisible = true;
            ImgBanqueActuelle.IsVisible = true;

            //await Navigation.PushModalAsync(new GestionBanque());
        }

        async void OnClickedRetour(object sender, EventArgs args)
        {
            await Bouton.ScaleXTo(1, 50);
            await Bouton.ScaleYTo(1, 50);
            ImgBanqueActuelle.IsVisible = false;
            stackpannel.IsVisible = false;
            await Bouton.TranslateTo(0, 0, 50);
            BoutonRetour.IsVisible = false;
        }

        public async void loadInscription()
        {
            await Navigation.PushModalAsync(new MainPage());
            BindingContext=Mgr;
        }
    }
}