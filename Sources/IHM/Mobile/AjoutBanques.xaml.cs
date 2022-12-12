using Model;
using System.Diagnostics;

namespace IHM.Mobile;

public partial class AjoutBanques : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public AjoutBanques()
	{
		InitializeComponent();
        BindingContext = Mgr;
        Mgr.importBanques();
    }

     private async void ImportOFX_Clicked(object sender, EventArgs e)
     {
         PickOptions options = new PickOptions();
         options.PickerTitle = "Choisir un fichier OFX";

        var result = await FilePicker.Default.PickAsync(options);
        if (result != null)
        {
            if (result.FileName.EndsWith("ofx", StringComparison.OrdinalIgnoreCase))
            {
                string file = File.ReadAllText(result.FullPath).ToString();
                //return file;
            }
        }
        else
        {
            throw new FileLoadException("Imposible de charger le fichier");
        }


    }

}