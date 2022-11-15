using Model;

namespace IHM;

public partial class Operations : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
	public Operations()
	{
		InitializeComponent();
		BindingContext = Mgr;
        double test = Mgr.recupTotalSolde();
        double i = test / 2000;
        PrgressAnimationBar(i);
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
		double test = Mgr.recupTotalSolde();
        double i = test/2000;
		PrgressAnimationBar(i);
        UpdateArc();
    }
    private async void UpdateArc()
    {
        ActualisationButton.IsEnabled = false;
        int timeRemaining = 60;
        while (timeRemaining != 0)
        {
            timeRemaining--;
            await Task.Delay(1000);
        }
        ActualisationButton.IsEnabled = true;
    }
    private async void PrgressAnimationBar(double progress)
	{
        await ProgressBarSolde.ProgressTo(0.75, 500, Easing.Linear);
    }
}