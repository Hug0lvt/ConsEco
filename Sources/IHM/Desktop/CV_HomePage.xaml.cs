using Model;

namespace IHM.Desktop;

public partial class CV_HomePage : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_HomePage()
	{
		InitializeComponent();
        
        Mgr.LoadBanque();
        Mgr.LoadCompte();
        Mgr.LoadBanqueDispo();
        BindingContext = Mgr;

       
      
    }

    private void ImportOFX_Clicked(object sender, EventArgs e)
    {

    }

    private void AddBanque_Clicked(object sender, EventArgs e)
    {

    }
}