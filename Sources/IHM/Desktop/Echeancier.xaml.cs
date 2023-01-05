using Model;

namespace IHM.Desktop;

public partial class Echeancier : ContentView
{
	List<Echeance> echeancier;
	public Echeancier()
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

	private void SaveEcheance_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_EnregistrerEcheance();
	}

	private void DelEcheance_Clicked(object sender, EventArgs e)
	{
        windowAjout.Content = new CV_SupprimerEcheance();
	}
}