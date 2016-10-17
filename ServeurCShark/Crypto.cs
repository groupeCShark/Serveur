﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ServeurCShark
{
    public class Crypto
    {
        private static string keyString = "ABCDEFEGHIJKLMNO";
        private static string ivString = "abcdefeghijklmno";

        public static string Encrypt(string plainText)
        {
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = Encoding.UTF8.GetBytes(ivString);

            // Check arguments
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("keyString");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("ivString");

            byte[] encrypted;
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged() { Key = key, IV = iv })
            {
                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            return System.Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipher = System.Convert.FromBase64String(cipherText);
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = Encoding.UTF8.GetBytes(ivString);

            // Check arguments
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("keyString");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("ivString");

            string decrypted;
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged() { Key = key, IV = iv })
            {
                ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream(cipher))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}