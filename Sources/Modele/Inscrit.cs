using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Model;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Model
{
    public class Inscrit:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Mail
        {
            get => mail;
            set
            {
                if (value.Length == 0)
                {
                    throw new InvalidMailException(value, "Longueur d'un mail doit être superieur a 0");
                }
                if (!Regex.IsMatch(value, "(@)(.+)"))
                {
                    throw new InvalidMailException(value, "Un mail doit contenir le symbole '@'");
                }
                mail = value;
            }
        }
        private string mail;

        

        public string Mdp
        {
            get => mdp;
            set
            {
                /*if (value.Length <= 8)
                {
                    throw new InvalidPasswordException(value, "La longeur d'un mot de passe doit être obligatoirement superieure a 8");
                }
                if (!Regex.IsMatch(value, "[A-Z]+"))
                {
                    throw new InvalidPasswordException(value, "Le mot de passe doit contenir au moins une lettre majuscule");
                }
                if (!Regex.IsMatch(value, "[0-9]+"))
                {
                    throw new InvalidPasswordException(value, "Le mot de passe doit contenir au moins un chiffre");
                }*/
                mdp = value;
            }
        }
        private string mdp;

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public double SoldeTotal { get; private set; }
        public Devises Dev { get; private set; }
        public List<Banque> LesBanques 
        {
            get => lesBanques;
            set
            {
                if(lesBanques!=value)
                {
                    lesBanques = value;
                    OnPropertyChanged(nameof(LesBanques));
                }
            }
        }

        private List<Banque> lesBanques;

        [JsonConstructor]
        public Inscrit(int id, string nom, string mail, string prenom, string mdp, double soldeTotal = 0)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
            lesBanques = new();
        }
        public Inscrit(int id, string nom, string mail, string prenom, string mdp, double soldeTotal, List<Banque> lesbanques)
            : this(id, nom, mail, prenom, mdp, soldeTotal)
        {
            LesBanques = lesbanques;
        }

        public Inscrit(List<Banque> lesbanques)
        {
            LesBanques = lesbanques;
        }

        public void ajouterBanque(Banque banque)
        {
            LesBanques.Add(banque);
        }

        public void SupprimerBanque(Banque banque)
        {
            LesBanques.Remove(banque);

        }

        public void ChoisirDevise(Devises devise)
        {
            Dev = devise;
        }

        public override string ToString()
        {
            return Id + " " + Nom + " " + Prenom + " " + Mail + " " + Mdp; 
        }
    }
}
