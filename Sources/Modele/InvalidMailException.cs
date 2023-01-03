using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Exception déclenché lorsque un mail invalide est rentré.
    /// </summary>
    public class InvalidMailException : ArgumentException
    {
        /// <summary>
        /// Représente le mail invalide.
        /// </summary>
        private string Mail { get; set; }

        public InvalidMailException():base() 
        { }

        /// <summary>
        /// Stocke le mail invalide dans la variable Mail et rentre le message d'erreur.
        /// </summary>
        /// <param name="mail">Le mail qui est invalide</param>
        public InvalidMailException(string mail):
            base(String.Format("{0} n'est pas un mail valide.", mail))
        {
            Mail = mail;
        }
        public InvalidMailException(string mail, string message): 
            base(message)
        {
            Mail = mail;
        }

        public InvalidMailException(string mail, string message, Exception innerException) :
           base(message, innerException)
        {
            Mail = mail;
        }
    }
}
