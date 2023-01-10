using Newtonsoft.Json;
using System.ComponentModel;

namespace Model
{
    public class Compte : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Identifiant { get; set; }
        public string Nom { get; set; }
        public double Solde { get; set; }
        public DateTime DerniereModification { get; set; }
        public List<Operation> LesOpe 
        {
            get => lesOpe;
            set
            {
                if (lesOpe != value)
                {
                    lesOpe = value;
                    OnPropertyChanged(nameof(LesOpe));
                }
            }
        } 
        private List<Operation> lesOpe = new List<Operation>();
        public List<Planification> LesPla { get; set; } = new List<Planification>();
        public List<Echeance> LesEch { get; set; } = new List<Echeance>();

        [JsonConstructor]
        public Compte(string id, string nom)
        {
            Identifiant = id;
            Nom = nom;
            Solde = 0;
            DerniereModification = DateTime.Now;
        }
        public Compte(string id,string nom, double solde) : base()
        {
            Solde = solde;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesOpe = lesOpe;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesPla = lesPla;
            LesOpe = lesOpe;
        }
        public Compte(string id, string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla, List<Echeance> lesEch)
        {
            Identifiant = id;
            Nom = nom;
            Solde = solde;
            DerniereModification = DateTime.Now;
            LesPla = lesPla;
            LesOpe = lesOpe;
            LesEch = lesEch;
        }

        /// <summary>
        /// Permet de modifier le solde présent sur le compte.
        /// </summary>
        /// <param name="s">Nouvelle quantité d'argent présent sur le compte.</param>
        public void modifierSolde(double s)
        {
            Solde = s;
        }

        
        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ajouterOperation(Operation o)
        {
            if (o == null) throw new NullReferenceException();
            LesOpe.Add(o);
        }

        public void cacherOperation(Operation o)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de supprimer une operation de la liste LesOpe
        /// </summary>
        /// <param name="o">Objet de type operation devant être supprimé de la liste</param>
        public void supprimerOperation(Operation o)
        {
            LesOpe.Remove(o);
        }

        /// <summary>
        /// Sert à ajouter une echenance à la liste LesEch
        /// </summary>
        /// <param name="e">Objet de type échéance à ajouter à la liste</param>
        /// <exception cref="NullReferenceException">Déclenchée quand l'opération placé en paramètre est nulle.</exception>
        public void ajoutEcheance(Echeance e)
        {
            if (e == null) throw new NullReferenceException();
            LesEch.Add(e);
        }

        /// <summary>
        /// Permet de supprimer une echeance de la liste LesEch
        /// </summary>
        /// <param name="e">Objet de type echeance devant être supprimé de la liste</param>
        public void supprimerEcheance(Echeance e)
        {
            LesEch.Remove(e);
        }

        /// <summary>
        /// Sert à ajouter une planification à la liste LesPla
        /// </summary>
        /// <param name="p">Objet de type planification à ajouter à la liste</param>
        /// <exception cref="NullReferenceException">Déclenchée quand l'opération placé en paramètre est nulle.</exception>
        public void ajoutPlanification(Planification p)
        {
            if (p == null) throw new NullReferenceException();
            LesPla.Add(p);
        }

        /// <summary>
        /// Permet de supprimer une planification de la liste LesPla
        /// </summary>
        /// <param name="p">Objet de type planification devant être supprimé de la liste</param>
        public void supprimerPlanification(Planification p)
        {
            LesPla.Remove(p);
        }

        /// <summary>
        /// Permet de rédéfinir la méthode Equals en comparant le type des 2 objets.
        /// </summary>
        /// <param name="obj">L'objet dont on souhaite savoir s'il est de type compte</param>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Compte objCompte = (Compte) obj;
                if(objCompte.Identifiant == Identifiant && objCompte.DerniereModification == DerniereModification) return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Identifiant + " " + Nom + " " + Solde + " "  + DerniereModification;
        }

    }
}