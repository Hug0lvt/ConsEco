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
		ButPla.BackgroundColor = Colors.Yellow; ButPla.TextColor = Colors.Black;
        ButEch.BackgroundColor = Colors.Yellow; ButEch.TextColor = Colors.Black;
        ButOpe.BackgroundColor = Colors.Yellow; ButOpe.TextColor = Colors.Black;
        ButCom.BackgroundColor = Colors.Yellow; ButCom.TextColor = Colors.Black;
        ButAcc.BackgroundColor = Colors.Yellow; ButAcc.TextColor = Colors.Black;
        ButSta.BackgroundColor = Colors.Yellow; ButSta.TextColor = Colors.Black;
    }

    private void Button_planification(object sender, EventArgs e)
	{
        RetourFormeBase();
		ButPla.TextColor = Colors.White;
        ButPla.BackgroundColor = Colors.Coral;
        mainCV.Content= new CV_Planification();
    }

    private void Button_echeancier(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButEch.TextColor = Colors.White;
        ButEch.BackgroundColor = Colors.Red;
        mainCV.Content = new Echeancier();
    }

	private void Button_operation(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButOpe.TextColor = Colors.White;
        ButOpe.BackgroundColor = Colors.Red;
        mainCV.Content = new Operations();
    }

	private void Button_compte(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButCom.TextColor = Colors.White;
        ButCom.BackgroundColor = Colors.Red;
        mainCV.Content = new Compte();
    }

	private void Button_statistiques(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButSta.TextColor = Colors.White;
        ButSta.BackgroundColor = Colors.Red;
        mainCV.Content = new CV_Statistiques();
    }
}