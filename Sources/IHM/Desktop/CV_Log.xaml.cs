
using Model;


namespace IHM.Desktop;

public partial class CV_Log : ContentView
{
    public Manager Mgr => (App.Current as App).Manager;
    public CV_Log()
	{
		InitializeComponent();

        BindingContext = Mgr.User;
    }

    private void Button_Quitter(object sender, EventArgs e)
    {
        Microsoft.Maui.Controls.Application.Current?.CloseWindow(Microsoft.Maui.Controls.Application.Current.MainPage.Window);
    }
}