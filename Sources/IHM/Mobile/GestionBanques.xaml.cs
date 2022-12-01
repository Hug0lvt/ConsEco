using Model;

namespace IHM.Mobile;

public partial class GestionBanques : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    public GestionBanques()
	{
		InitializeComponent();
		BindingContext= Mgr;
        //Mgr.BanquesDisponibleInApp=Mgr.importBanques();

    }
}