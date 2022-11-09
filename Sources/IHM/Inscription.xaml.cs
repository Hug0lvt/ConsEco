using Model;
using Email = Model.Email;

namespace IHM;

public partial class Inscription : ContentPage
{
    private string code;
    public Manager Mgr => (App.Current as App).Manager;
    public Inscription()
	{
		InitializeComponent();
	}
    public void InscriptionOnClicked(object sender, EventArgs e)
	{
        if (EntryNewName.Text == null || EntryNewMail.Text == null || EntryConfirmationPassword.Text == null || EntryNewPassword.Text == null ||
            EntryNewSurname.Text == null)
        {
            AffichError("Champ invalide", "Veuillez compléter tout les champs", "OK");
        }
        else
        {
            if(EntryNewPassword.Text.Equals(EntryConfirmationPassword.Text)) {
                if (Mgr.existEmail(EntryNewMail.Text))
                {
                    AffichError("Mail existant", "un compte porte déjà cette adresse mail, veuillez en changer", "OK");
                }
                else
                {
                    try
                    {
                        Random generator = new Random();
                        code = generator.Next(0, 1000000).ToString("D6");
                        Email.CreateMail(EntryNewMail.Text, code);
                        ValidateReceptCode.IsVisible = true;
                    }
                    catch (Exception ex)
                    {
                        AffichError("Information invalide", ex.Message, "OK");
                    }
                }
            }
            else
            {
                AffichError("Mot de passe de confirmation invalide", "Veuillez mettre deux mots de passe identiques", "OK");
            }
        }
    }
    private void ValideCode(object sender, EventArgs e)
    {
        if (EntryCodeRecept.Text == code)
        {
            Inscrit inscrit = new Inscrit(Mgr.lastInscrit() + 1, EntryNewName.Text, EntryNewMail.Text, EntryNewSurname.Text, EntryNewPassword.Text);
            Mgr.createInscrit(inscrit);
            AffichError("compte créé", "Compte bien créé", "OK");
            NavigateTo("..");
        }
        else
        {
            AffichError("Code non identique", "Veuillez entrer le même code que celui reçu par mail", "OK");
        }
    }

    private async void AffichError(string s, string s1, string s2)
    {
        await DisplayAlert(s, s1, s2);
    }

    private async void NavigateTo(string s)
    {
        await Shell.Current.GoToAsync(s);
    }
}