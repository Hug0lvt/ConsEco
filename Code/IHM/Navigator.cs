using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IHM
{
    public class Navigator : INotifyPropertyChanged
    {
        public const string PART_COMPTE = "Compte";
        public const string PART_OPERATION = "Opération";
        public const string PART_ECHEANCIER = "Echéancier";
        public const string PART_PLANNIFICATION = "Plannification";

        public const string PART_MAIN = "Main";
        public const string PART_CONNEXION = "Connexion";
        public const string PART_INSCRIPTION = "Inscription";
        public const string PART_MODIFSOLDE = "ModifSolde";

        public ReadOnlyDictionary<string, Func<UserControl>> WindowPart { get; private set; }

        Dictionary<string, Func<UserControl>> windowPart { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            [PART_MAIN] = () => new UCBienvenue(),
            [PART_CONNEXION] = () => new UCConnexion(),
            [PART_COMPTE] = () => new UCCompte(),
            [PART_OPERATION] = () => new UCOperation(),
            [PART_ECHEANCIER] = () => new UCEcheancier(),
            [PART_PLANNIFICATION] = () => new UCPlannification(),
            [PART_INSCRIPTION] = () => new UCInscription(),
            [PART_MODIFSOLDE] = () => new UCModifSolde(),
        };


        public Navigator()
        {
            WindowPart = new ReadOnlyDictionary<string, Func<UserControl>>(windowPart);

            SelectedUserControlCreator = windowPart.First();
        }

        public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreator
        {
            get => selectedUserControlCreator;
            set
            {
                if (selectedUserControlCreator.Equals(value)) return;
                selectedUserControlCreator = value;
                OnPropertyChanged();
            }
        }

        private KeyValuePair<string, Func<UserControl>> selectedUserControlCreator;

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void NavigateTo(string windowPartName)
        {
            if (WindowPart.ContainsKey(windowPartName))
            {
                SelectedUserControlCreator = WindowPart.Single(kvp => kvp.Key == windowPartName);
            }
        }
    }
}
