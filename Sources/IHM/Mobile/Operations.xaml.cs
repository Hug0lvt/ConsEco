using System.Diagnostics;
using Model;

namespace IHM.Mobile;

public partial class Operations : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    List<Operation> operations;
    public Operations()
	{
		InitializeComponent();
        //BindingContext = Mgr;

        operations = new List<Operation>();
        operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));
        operations.Add(new("op", 33.44, DateTime.Now, MethodePayement.CB, TagOperation.Divers, false));
        operations.Add(new("course", 45.20, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("Orange", 50, DateTime.Now, MethodePayement.CB, TagOperation.Divers, true));
        operations.Add(new("EDF", 55.80, DateTime.Now, MethodePayement.Virement, TagOperation.Energie, true));



        BindingContext = operations;
    }
}