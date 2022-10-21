using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InvalidPasswordException : ArgumentException
    {
        private string Mdp { get; set; }
        public InvalidPasswordException() : base()
        { }

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
