using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

namespace SEC
{
    public class Cripto
    {
        //Singleton logic.
        private static Cripto _instance;

        public static Cripto GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Cripto();
            }

            return _instance;
        }

        //Genera un hash MD5 en base a un texto.
        public string GetHash(string texto)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));


            return sBuilder.ToString();
        }

        //Compara un texto con un hash y valida si son iguales.
        public bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetHash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return (0 == comparer.Compare(hashOfInput, hash)) ? true : false;
        }

        //Obtengo del archivo config la secret key y la convierto a bytes
        private byte[] KeyToBytes()
        {
            string keyStr = ConfigurationManager.AppSettings["SecretKey"];
            byte[] key = Encoding.ASCII.GetBytes(keyStr);

            return key;
        }

        //Encripto un string usand el algporitmo AES, retorno bytes.
        public string Encrypt(string plainText)
        {
            byte[] Key = this.KeyToBytes();
            byte[] encrypted;
            byte[] IV;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            return Convert.ToBase64String(combinedIvCt);

        }

        //Decripto un string usando el algoritmo AES, recibo la clave como bytes.
        public string Decrypt(byte[] cipherTextCombined)
        {
            byte[] Key = this.KeyToBytes();
            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                byte[] IV = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[cipherTextCombined.Length - IV.Length];

                Array.Copy(cipherTextCombined, IV, IV.Length);
                Array.Copy(cipherTextCombined, IV.Length, cipherText, 0, cipherText.Length);

                aesAlg.IV = IV;

                aesAlg.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

    }
}