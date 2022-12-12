using Model;

namespace IHM.Mobile;

public partial class DashBoard : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public DashBoard()
    {
        InitializeComponent();
        //Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));


        if (Mgr.User == null)
        {
            loadPage(new MainPage());

        }

        if (!Mgr.testConnexionAsDatabase())
        {
            loadPage(new ErrorPage());

        }

    }

    public async void loadPage(Page p)
    {
        await Navigation.PushModalAsync(p);
    }

    private void Banques_Clicked(object sender, EventArgs e)
    {
        loadPage(new GestionBanques());
    }
}
