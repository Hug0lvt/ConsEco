using Model;

namespace IHM.Mobile;

public partial class Operations : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
	public Operations()
	{
		InitializeComponent();
		BindingContext = Mgr;
    }
    
}