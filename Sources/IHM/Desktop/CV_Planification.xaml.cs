using Microsoft.Maui.Controls.Internals;
using Model;

namespace IHM.Desktop;

public partial class CV_Planification : ContentView
{



    public Manager Mgr => (App.Current as App).Manager;

    public CV_Planification()
	{
		InitializeComponent();

		Mgr.LoadBanque();
		Mgr.LoadCompte();

        BindingContext = Mgr;

    }


	private void Button_Clicked(object sender, EventArgs e)
	{
		windowAjout.Content = new CV_AddPlanification();
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_DeletePlanification();
    }
}