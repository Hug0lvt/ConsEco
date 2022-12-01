namespace IHM.Composant;

public partial class BanqueDispo : ViewCell
{
	public BanqueDispo()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ImageBanqueProperty =
    BindableProperty.Create("ImageBanque", typeof(string), typeof(BanqueDispo), "");

    public string ImageBanque
    {
        get { return (string)GetValue(ImageBanqueProperty); }
        set { SetValue(ImageBanqueProperty, value); }
    }

    private void Banque_Clicked(object sender, EventArgs e)
    {

    }
}