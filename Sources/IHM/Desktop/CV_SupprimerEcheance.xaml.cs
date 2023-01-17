using Model;

namespace IHM.Desktop;

public partial class CV_SupprimerEcheance : ContentView
{
    List<Echeance> echeancier;
	public CV_SupprimerEcheance()
	{
		InitializeComponent();


        echeancier = new List<Echeance>();

        echeancier.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        echeancier.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        echeancier.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        echeancier.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));
        echeancier.Add(new("Eau", 55, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Amazon", 103.30, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        echeancier.Add(new("Mutuelle", 38.50, DateTime.Now, MethodePayement.Prevelement, TagOperation.Santé, true));
        echeancier.Add(new("Loyer", 500, DateTime.Now, MethodePayement.Virement, TagOperation.Habitation, true));

        BindingContext = echeancier;
    }

	private void Button_Clicked(object sender, EventArgs e)
	{

	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{

	}
}