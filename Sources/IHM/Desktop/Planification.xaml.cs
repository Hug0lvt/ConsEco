using Model;

namespace IHM.Desktop;

public partial class Planification : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public Planification()
	{
		InitializeComponent();
		BindingContext = Mgr;
		
		
	}
}