using Model;
using Email = Model.Email;

namespace IHM;

public partial class ForgetPassword : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
	private string code;
	public ForgetPassword()
	{
		InitializeComponent();
	}
    public void SearchEmail(object sender, EventArgs e)
    {
		if (EntryMail.Text == null)
		{
			AffichError("Email inconnue", "Aucun compte existant portant cette adresse mail", "OK");
		}
		if (Mgr.existEmail(EntryMail.Text)){
            Random generator = new Random();
            code = generator.Next(0, 1000000).ToString("D6");
            Email.CreateMail(EntryMail.Text, code);
			ValidateReceptCode.IsVisible = true;
		}
	}
    private async void AffichError(string s, string s1, string s2)
    {
        await DisplayAlert(s, s1, s2);
    }

	private void ValideCode(object sender, EventArgs e)
	{
		if(EntryCodeRecept.Text == code)
		{
			NavigateTo();	
		}
		else
		{
			AffichError("Code non identique", "Veuillez entrer le même code que celui reçu par mail", "OK");
		}
	}

	public async void NavigateTo()
	{
		await Navigation.PushModalAsync(new ChangePassword(EntryMail.Text));
	}
}