using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public class Hash
    {
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

        public bool IsEqualHash(string mdpBdd, string mdpSent)
        {
            string hashedMdpSent = CreateHashCode(mdpSent);
            return hashedMdpSent.Equals(mdpBdd);
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
