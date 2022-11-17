using Model;

namespace IHM.Mobile;

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

    public async void loadInscription()
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}