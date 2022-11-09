using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InvalidMailException : ArgumentException
    {
        private string Mail { get; set; }
        public InvalidMailException():base() 
        { }

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
