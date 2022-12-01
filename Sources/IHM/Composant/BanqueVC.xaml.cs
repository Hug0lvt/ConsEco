namespace IHM.Composant;

public partial class BanqueVC : ViewCell
{
	public BanqueVC()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty NomBanqueProperty =
    BindableProperty.Create("NomBanque", typeof(string), typeof(BanqueVC), "");

    public string NomBanque
    {
        get { return (string)GetValue(NomBanqueProperty); }
        set { SetValue(NomBanqueProperty, value); }
    }

    public static readonly BindableProperty DateLastReloadProperty =
      BindableProperty.Create("DateLastReload", typeof(string), typeof(BanqueVC), "");

    public string DateLastReload
    {
        get { return (string)GetValue(DateLastReloadProperty); }
        set { SetValue(DateLastReloadProperty, value); }
    }

    private void MaBanque_Clicked(object sender, EventArgs e)
    {

    }
}