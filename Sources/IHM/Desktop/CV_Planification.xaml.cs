using Microsoft.Maui.Controls.Internals;
using Model;

namespace IHM.Desktop;

public partial class CV_Planification : ContentView
{
   
    public CV_Planification()
	{
		InitializeComponent();

	

		

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