using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public static class Hash
    {
        public static string CreateHashCode(string mdp)

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

        public static bool IsEqualHash(string mdpBdd, string mdpSent)
        {
            string hashedMdpSent = Hash.CreateHashCode(mdpSent);
            return hashedMdpSent.Equals(mdpBdd);
        }
    }
}
