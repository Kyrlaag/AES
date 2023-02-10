using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace AES
{
    class Class1
    {
        public static string toEncode(string key,string text)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encoder = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memSt = new MemoryStream())
                {
                    using (CryptoStream crSt = new CryptoStream((Stream)memSt, encoder, CryptoStreamMode.Write))
                    {
                        using (StreamWriter stWr = new StreamWriter((Stream)crSt))
                        {
                            stWr.Write(text);
                        }

                        array = memSt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string toDecode(string key, string text2)
        {
            byte[] iv = new byte[16];
            byte[] aa = Convert.FromBase64String(text2);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decoder = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoSt = new MemoryStream(aa))
                {
                    using (CryptoStream crySt = new CryptoStream((Stream)memoSt, decoder, CryptoStreamMode.Read))
                    {
                        using (StreamReader strRead = new StreamReader((Stream)crySt))
                        {
                            return strRead.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}