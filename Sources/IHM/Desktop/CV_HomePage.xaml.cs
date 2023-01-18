using Model;

namespace IHM.Desktop;

public partial class CV_HomePage : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_HomePage()
	{
		InitializeComponent();
     

        BindingContext = Mgr;
        //Mgr.LoadBanques();
    }
}