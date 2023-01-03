using Microsoft.Maui.Controls.Internals;
using Model;
using static AndroidX.ConstraintLayout.Core.Motion.Utils.HyperSpline;

namespace IHM.Desktop;

public partial class CV_Planification : ContentView
{
   //pour test sur la listView en attendant le stub ou la pers
	public List<Compte> listTest = new List<Compte>();


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