using Microsoft.Maui.Graphics.Text;

namespace IHM.Desktop;

public partial class Dashboard 
{
	public Dashboard()
	{
		InitializeComponent();
	}

	private void Button_planification(object sender, EventArgs e)
	{
		mainCV.Content= new CV_Planification();
    }

	private void Button_echeancier(object sender, EventArgs e)
	{
       
    }

	private void Button_operation(object sender, EventArgs e)
	{
        
    }

	private void Button_compte(object sender, EventArgs e)
	{
        
    }

	private void Button_Clicked(object sender, EventArgs e)
	{

	}
}