using Model;

namespace IHM.Mobile;

public partial class Planification : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public Planification()
	{
		InitializeComponent();
        BindingContext = Mgr;
        Mgr.LoadCompte();

    }

    
}