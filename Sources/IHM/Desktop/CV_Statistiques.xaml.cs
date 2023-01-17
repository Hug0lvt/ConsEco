namespace IHM.Desktop;
using Model;

public partial class CV_Statistiques : ContentView
{
	public List<Operations> operations;
	public CV_Statistiques()
	{
		InitializeComponent();

        List<Operation> operations;
       

            // Temporaire pour établir le binding de la vue
            operations = new List<Operation>();
            operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
            operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
            operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
            operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
            operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
            operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Carburant, true));

        BindingContext = operations;
    }
}