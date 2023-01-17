using Model;
using System.Diagnostics;

namespace IHM.Mobile;

public partial class DashBoard : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    List<Operation> operations;
    public DashBoard()
    {
        InitializeComponent();
        //Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));
        //
        BindingContext = Mgr;

        if (Mgr.User == null)
        {
            loadPage(new MainPage());

        }

        operations = new List<Operation>();
        operations.Add(new("Internet", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("Course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        operations.Add(new("Spotify", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("Garage", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));

        /*if (!Mgr.Pers.TestConnexion())
        {
            loadPage(new ErrorPage());
            Debug.WriteLine("cc");
        }*/
        DerniereOpe.ItemsSource = operations;
        
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
