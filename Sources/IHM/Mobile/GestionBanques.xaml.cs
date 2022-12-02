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
        //Mgr.importBanquesForUser(Mgr.SelectedInscrit);

    }
}