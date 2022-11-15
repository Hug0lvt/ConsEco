using Model;
using Email = Model.Email;

namespace IHM;

public partial class ForgetPassword : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
	private string code;
	private DateTime _startTime;
	private CancellationTokenSource _cancellationTokenSource;

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
			ConnexionButton.IsEnabled = false;
			UpdateArc();
		}
	}
    private async void AffichError(string s, string s1, string s2)
    {
        await DisplayAlert(s, s1, s2);
    }
    private async void UpdateArc()
    {
		int timeRemaining = 60;
        while (timeRemaining != 0)
        {
            ConnexionButton.Text = $"{timeRemaining}";

            timeRemaining--;

            await Task.Delay(1000);
        }

		ConnexionButton.Text = "valider Email";
		ConnexionButton.IsEnabled = true;
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