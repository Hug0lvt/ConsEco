using Model;

namespace IHM.Mobile;

public partial class Planification : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    List<Operation> operations;
    public Planification()
	{
		InitializeComponent();
        //BindingContext = Mgr;
        //Routing.RegisterRoute(nameof(DashBoard), typeof(DashBoard));

        operations = new List<Operation>();
        operations.Add(new("Vulcan Mag", 3.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("Apple Music", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        



        Ech.ItemsSource = operations;

    }

    
}