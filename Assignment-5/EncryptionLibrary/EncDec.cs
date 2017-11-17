using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class EncDec
    {
        static byte[] seed = ASCIIEncoding.ASCII.GetBytes("key92851");

        public static string Encrypt(string plainString)
        {
            // encryption using DES 
            if (String.IsNullOrEmpty(plainString))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream,
                saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);
            StreamWriter sWriter = new StreamWriter(cStream);

            sWriter.Write(plainString);
            sWriter.Flush(); // Buffer flush is necessary when switching writing modes
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int) mStream.Length);
        }

        public static string Decrypt(string encryptedString)
        {
            if (String.IsNullOrEmpty(encryptedString))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }
            // decryption using DES 
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream
                (Convert.FromBase64String(encryptedString));
            CryptoStream cStream = new CryptoStream(memStream,
                saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);
            return reader.ReadLine();
        }
    }
}
