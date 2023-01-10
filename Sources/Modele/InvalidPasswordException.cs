using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Excepion déclenchée lorsque un mot de passe est invalide.
    /// </summary>
    public class InvalidPasswordException : ArgumentException
    {
        /// <summary>
        /// Représente le mot de passe invalide.
        /// </summary>
        private string Mdp { get; set; }
        public InvalidPasswordException() : base()
        { }


        /// <summary>
        /// Stocke le mot de passe invalide dans la variable Mdp et rentre le message d'erreur.
        /// </summary>
        /// <param name="mdp">Le mot de passe qui est invalide</param>
        /// 
        public InvalidPasswordException(string mdp) :
            base(String.Format("{0} n'est pas un mot de passe valide.", mdp))
        {
            Mdp = mdp;
        }
        public InvalidPasswordException(string mdp, string message) :
            base(message)
        {
            Mdp = mdp;
        }

        public InvalidPasswordException(string mdp, string message, Exception innerException) :
           base(message, innerException)
        {
            Mdp = mdp;
        }
    }
}
