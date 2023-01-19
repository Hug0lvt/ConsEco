using Model;
using System.Diagnostics;

namespace IHM.Mobile;

public partial class DashBoard : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    
    public DashBoard()
    {
        InitializeComponent();
        Mgr.LoadBanque();
        
        BindingContext = Mgr;

        if (Mgr.User == null)
        {
            loadPage(new MainPage());

        }

        

        /*if (!Mgr.Pers.TestConnexion())
        {
            loadPage(new ErrorPage());
            Debug.WriteLine("cc");
        }*/
        
        
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
