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
        public const string PART_MAIN = "Main";
        public const string PART_CONNEXION = "Connexion";
        public const string PART_INSCRIPTION = "Inscription";

        public const string PART_TABLEAU_DE_BORD = "Tableau de Bord";

        public const string PART_COMPTE = "Compte";
        public const string PART_AJOUTER_BANQUE = "Ajouter une banque";
        public const string PART_SUPPRIMER_BANQUE = "Supprimer une banque";
        public const string PART_AJOUTER_COMPTE = "Ajouter une compte";
        public const string PART_SUPPRIMER_COMPTE = "Supprimer un compte";
        public const string PART_MODIFSOLDE = "ModifSolde";

        public const string PART_OPERATION = "Opération";

        public const string PART_ECHEANCIER = "Echéancier";
        public const string PART_AJOUTER_ECHEANCE = "Enregistrer une échéance";
        public const string PART_SUPPRIMER_ECHEANCE = "Supprimer une échéance";

        public const string PART_PLANIFICATION = "Planification";
        public const string PART_AJOUTER_PLANIFICATION = "Ajouter une planification";
        public const string PART_SUPPRIMER_PLANIFICATION = "Supprimer une planification";

        public ReadOnlyDictionary<string, Func<UserControl>> WindowPart { get; private set; }

        Dictionary<string, Func<UserControl>> windowPart { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            [PART_MAIN] = () => new UCBienvenue(),
            [PART_CONNEXION] = () => new UCConnexion(),
            [PART_COMPTE] = () => new UCCompte(),
            [PART_OPERATION] = () => new UCOperation(),
            [PART_ECHEANCIER] = () => new UCEcheancier(),
            [PART_PLANIFICATION] = () => new UCPlannification(),
            [PART_INSCRIPTION] = () => new UCInscription(),
            [PART_MODIFSOLDE] = () => new UCModifSolde(),
            [PART_AJOUTER_BANQUE] = () => new UCAjouterBanque(),
            [PART_SUPPRIMER_BANQUE] = () => new UCSupprimerBanque(),
            [PART_AJOUTER_COMPTE] = () => new UCAjouterCompte(),
            [PART_SUPPRIMER_COMPTE] = () => new UCSupprimerCompte(),
            [PART_AJOUTER_ECHEANCE] = () => new UCAjouterEcheance(),
            [PART_SUPPRIMER_ECHEANCE] = () => new UCSupprimerEcheance(),
            [PART_AJOUTER_PLANIFICATION] = () => new UCAjouterPlanification(),
            [PART_SUPPRIMER_PLANIFICATION] = () => new UCSupprimerPlanification(),
            [PART_TABLEAU_DE_BORD] = () => new UCTableauDeBord(),
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
