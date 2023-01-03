using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    /// <summary>
    /// Permet de gérer le hachage des mots de passe à des buts de sécurité.
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Permet d'obtenir le hachage du mot de passe
        /// </summary>
        /// <param name="mdp">Le mot de passe dont on souhaite obtenir le hachage.</param>
        /// <returns>Le mot de passe haché.</returns>
        public string CreateHashCode(string mdp)
        {
            string hashString = "";
            byte[] hash;
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(mdp));
            }
            foreach (byte b in hash)
            {
                hashString = hashString + b;
            }
            return hashString;
        }

        /// <summary>
        /// Permet de vérifier si 2 mots de passe haché sont les mêmes.
        /// </summary>
        /// <param name="mdpBdd"> Le mot de passe qui est contenu dans la base de donnée.</param>
        /// <param name="mdpSent"> Le mot de passe dont on souhaite savoir si il est égale à celui de la base de donnée.</param>
        /// <returns> Un boolean égale à True si les mots de passe sont égaux. </returns>
        public bool IsEqualHash(string mdpBdd, string mdpSent)
        {
            string hashedMdpSent = CreateHashCode(mdpSent);
            return hashedMdpSent.Equals(mdpBdd);
        }
    }
}
