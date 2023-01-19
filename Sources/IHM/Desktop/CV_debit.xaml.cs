using Model;

namespace IHM.Desktop;

public partial class CV_debit : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_debit()
	{
		InitializeComponent();
        Mgr.LoadBanque();
        Mgr.LoadCompte();

        BindingContext = Mgr;
    }

	private void Button_Annuler(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Dashboard());
    }

	private void Button_Valider(object sender, EventArgs e)
	{
        string nom = name.Text;
        double Montant = Double.Parse(montant.Text);
        string Type = type.Text;
        string Tag = tag.Text;
        DateTime Date = date.Date;
        TagOperation to2 = new TagOperation();
        MethodePayement mp2 = new MethodePayement();


        foreach (string mp in Enum.GetNames(typeof(MethodePayement)))
        {
            if (Equals(Type, mp))
            {
                mp2 = (MethodePayement)Enum.Parse(typeof(MethodePayement), Type);

            }
        }

        foreach (string to in Enum.GetNames(typeof(TagOperation)))
        {
            if (Equals(Tag, to))
            {
                to2 = (TagOperation)Enum.Parse(typeof(TagOperation), Tag);

            }
        }


        Operation operation = new Operation(nom, Montant, Date, mp2, to2, false, true);
        Mgr.effectuerOperation(Mgr.SelectedCompte, operation);
        Navigation.PushAsync(new Dashboard());
    }
}