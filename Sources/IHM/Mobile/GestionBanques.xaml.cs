using Model;
using System.Collections.ObjectModel;

namespace IHM.Mobile;

public partial class GestionBanques : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    public GestionBanques()
	{
		InitializeComponent();
		BindingContext= Mgr;
        Mgr.LoadBanques();

    }

    public async void loadPage(Page p)
    {
        await Navigation.PushModalAsync(p);
    }

    private void AddBanque_Clicked(object sender, EventArgs e)
    {
        loadPage(new AjoutBanques());
    }
}