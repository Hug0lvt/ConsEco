using Microsoft.Maui.Graphics.Text;
using Model;

namespace IHM.Desktop;

public partial class Dashboard 
{
    public Manager Mgr => (App.Current as App).Manager;

    public Dashboard()
	{
		InitializeComponent();

        BindingContext = Mgr.User;
        mainCV.Content = new CV_HomePage();

    }

	private void RetourFormeBase()
	{
		ButPla.BackgroundColor = Color.FromArgb("E1E1E1"); ButPla.TextColor = Colors.Black;
        ButEch.BackgroundColor = Color.FromArgb("E1E1E1"); ButEch.TextColor = Colors.Black;
        ButOpe.BackgroundColor = Color.FromArgb("E1E1E1"); ButOpe.TextColor = Colors.Black;
        ButCom.BackgroundColor = Color.FromArgb("E1E1E1"); ButCom.TextColor = Colors.Black;
        ButAcc.BackgroundColor = Color.FromArgb("E1E1E1"); ButAcc.TextColor = Colors.Black;
        ButSta.BackgroundColor = Color.FromArgb("E1E1E1"); ButSta.TextColor = Colors.Black;
        
       
    }

    private void Button_planification(object sender, EventArgs e)
	{
        RetourFormeBase();
		ButPla.TextColor = Colors.White;
        ButPla.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content= new CV_Planification();
    }

    private void Button_echeancier(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButEch.TextColor = Colors.White;
        ButEch.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new Echeancier();
    }

	private void Button_operation(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButOpe.TextColor = Colors.White;
        ButOpe.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new Operations();
    }

	private void Button_compte(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButCom.TextColor = Colors.White;
        ButCom.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new Compte();
    }

	private void Button_statistiques(object sender, EventArgs e)
	{
        RetourFormeBase();
        ButSta.TextColor = Colors.White;
        ButSta.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new CV_Statistiques();
    }

    private void ButAcc_Clicked(object sender, EventArgs e)
    {
        RetourFormeBase();
        ButAcc.TextColor = Colors.White;
        ButAcc.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new CV_HomePage();
    }

    private void ButLog_Clicked(object sender, EventArgs e)
    {
        RetourFormeBase();
        ButLog.TextColor = Colors.White;
        ButLog.BackgroundColor = Color.FromArgb("7FB196");
        mainCV.Content = new CV_Log();

    }

}