using Model;
using System.Diagnostics;

namespace IHM.Mobile;

public partial class ErrorPage : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;

    public const int TIME_TEST_DB = 15000;

    public ErrorPage()
	{
		InitializeComponent();
        startTestConnexion();
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    public void conIsActive()
    {
        while (!Mgr.testConnexionAsDatabase())
        {
            Thread.Sleep(TIME_TEST_DB);
        }

        ConnexionValide();
        return;
    }

    public void startTestConnexion()
    {
        Task testConnexion = new Task(() => conIsActive());
        testConnexion.Start();
    }

    private async void ConnexionValide()
    {
        await Navigation.PopModalAsync();
    }


}