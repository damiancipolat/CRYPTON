using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using System.Diagnostics;

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

        //Obtengo la clave de encriptacion de la configuracion.
        private string getEncriptionKey()
        {
            return ConfigurationManager.AppSettings["EncriptionKey"];
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

        //Encripta un string.
        public string Encrypt(string plainText)
        {
            Debug.WriteLine(">Encrypting:"+ plainText);
            string key = this.getEncriptionKey();

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        //Decrypt string.
        public string Decrypt(string cipherText)
        {
            Debug.WriteLine(">Decrypting:" + cipherText);
            string key = this.getEncriptionKey();
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}