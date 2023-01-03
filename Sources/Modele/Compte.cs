namespace Model
{
    /// <summary>
    /// Permet de créer et gérer des objets de type compte.
    /// </summary>
    public class Compte
    {
        /// <summary>
        /// Représente le nom du compte.
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Représente le solde présent sur ce compte.
        /// </summary>
        public double Solde { get; private set; }

        /// <summary>
        /// Liste de toutes les opérations présent sur ce compte.
        /// </summary>
        public List<Operation> LesOpe { get; private set; } = new List<Operation>();

        /// <summary>
        /// Liste de toutes les planifications présent sur ce compte.
        /// </summary>
        public List<Planification> LesPla { get; private set; } = new List<Planification>();

        /// <summary>
        /// Liste de toutes les échéanciers présent sur ce compte.
        /// </summary>
        public List<Echeance> LesEch { get; private set; } = new List<Echeance>();

        public Compte(string nom, double solde)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = new List<Operation>();
            LesPla = new List<Planification>();
            LesEch = new List<Echeance>();
        }

        public Compte(string nom, double solde, List<Operation> lesOpe)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
        }

        public Compte(string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
            LesPla = lesPla;
        }
        public Compte(string nom, double solde, List<Operation> lesOpe, List<Planification> lesPla, List<Echeance> lesEch)
        {
            Nom = nom;
            Solde = solde;
            LesOpe = lesOpe;
            LesPla = lesPla;
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

        /// <summary>
        /// Sert à ajouter une opération à la liste LesOpe
        /// </summary>
        /// <param name="o">Objet de type operation à ajouter à la liste</param>
        /// <exception cref="NullReferenceException">Déclenchée quand l'opération placé en paramètre est nulle.</exception>
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
            if(e == null) throw new NullReferenceException();
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
            if(p == null) throw new NullReferenceException();
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

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <remarks> Si quelqu'un à le temps, utiliser des templates pour améliorer la qualité du code.</remarks>
    }
}