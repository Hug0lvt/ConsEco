using Model;

namespace IHM.Desktop;

public partial class ChangePassword : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    private string MailUser;
    public ChangePassword(string mailUser)
    {
        InitializeComponent();
        MailUser = mailUser;
    }

    private void ValidationButton_Clicked(object sender, EventArgs e)
    {
        if (EntryNewMdp.Text == null || EntryNewMdpConfirmation.Text == null)
        {
            AffichError("Champ non valide", "Veuillez remplir tout les champs", "OK");
        }
        else
        {
            if (!EntryNewMdp.Text.Equals(EntryNewMdpConfirmation.Text))
            {
                AffichError("mot de passe non identique", "veuillez entrer des mots de passe identique", "OK");
            }
            else
            {
                Mgr.changePasswordBdd(MailUser, EntryNewMdp.Text);
                AffichError("mdp changé", "mot de passe bien changé", "ok");
                NavigateTo("../..");
            }
        }
    }

    private async void NavigateTo(string path)
    {
        await Shell.Current.GoToAsync(path);
    }

    private async void AffichError(string s, string s1, string s2)
    {
        await DisplayAlert(s, s1, s2);
    }
}