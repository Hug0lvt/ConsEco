using Microsoft.Maui.Controls.Internals;
using Model;

namespace IHM.Desktop;

public partial class CV_Planification : ContentView
{



    public Manager Mgr => (App.Current as App).Manager;

    List<Planification> planification;
    public CV_Planification()
	{
		InitializeComponent();

        planification = new List<Planification>();

        /*planification.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        planification.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        planification.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        planification.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        planification.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        planification.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        planification.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        planification.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        planification.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        planification.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        planification.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        */



       /* BindingContext = Mgr.AllCompte;*/

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