using Microsoft.Maui.Graphics.Text;

namespace IHM.Desktop;

public partial class Dashboard 
{

    public Dashboard()
	{
		InitializeComponent();

	}

	private void RetourFormeBase()
	{
		ButPla.BackgroundColor = Color.FromArgb("F7B548"); ButPla.TextColor = Colors.Black;
        ButEch.BackgroundColor = Color.FromArgb("F7B548"); ButEch.TextColor = Colors.Black;
        ButOpe.BackgroundColor = Color.FromArgb("F7B548"); ButOpe.TextColor = Colors.Black;
        ButCom.BackgroundColor = Color.FromArgb("F7B548"); ButCom.TextColor = Colors.Black;
        ButAcc.BackgroundColor = Color.FromArgb("F7B548"); ButAcc.TextColor = Colors.Black;
        ButSta.BackgroundColor = Color.FromArgb("F7B548"); ButSta.TextColor = Colors.Black;
    }

    private void Button_planification(object sender, EventArgs e)
	{
        RetourFormeBase();
		ButPla.TextColor = Colors.White;
        ButPla.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content= new CV_Planification();
    }

    private void Button_echeancier(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButEch.TextColor = Colors.White;
        ButEch.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new Echeancier();
    }

	private void Button_operation(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButOpe.TextColor = Colors.White;
        ButOpe.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new Operations();
    }

	private void Button_compte(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButCom.TextColor = Colors.White;
        ButCom.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new Compte();
    }

	private void Button_statistiques(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButSta.TextColor = Colors.White;
        ButSta.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new CV_Statistiques();
    }

    private void ButAcc_Clicked(object sender, EventArgs e)
    {
        RetourFormeBase();
        ButAcc.TextColor = Colors.White;
        ButAcc.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new CV_HomePage();
    }

    private void ButLog_Clicked(object sender, EventArgs e)
    {
        RetourFormeBase();
        ButLog.TextColor = Colors.White;
        ButLog.BackgroundColor = Color.FromArgb("DF775C");
        mainCV.Content = new CV_Log();
        
    }
}