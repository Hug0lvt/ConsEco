using Model;
using System.Windows.Input;

namespace IHM.Desktop;

public partial class MainPage : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public void ConnectionOnClicked(object sender, EventArgs e)
    {
        if (EntryMail.Text == null || EntryPassworld.Text == null)
        {
            AffichError("Champ invalide", "Veuillez compléter tout les champs", "OK");
        }
        else
        {
            if (Mgr.existEmail(EntryMail.Text))
            {
                if (Mgr.isEqualHash(Mgr.recupMdpBdd(EntryMail.Text), EntryPassworld.Text))
                {
                    Mgr.LoadInscrit(EntryMail.Text, EntryPassworld.Text);
                    ConnexionValide();
                }
                else
                {
                    AffichError("Mot de passe non valide", "Le mot de passe ne correspond pas à celui existant pout cette adresse mail", "OK");
                }
            }
            else
            {
                AffichError("Compte inexistant", "Email ou mot de passe invalide", "OK");
            }
        }
    }

    private async void ConnexionValide()
    {
        await Navigation.PopModalAsync();
    }

    private async void AffichError(string s, string s1, string s2)
    {
        await DisplayAlert(s, s1, s2);
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    //Exception à gérer pour cette version desktop
    public ICommand TapCommand => new Command<string>(async (page) => await Shell.Current.GoToAsync(page));
}