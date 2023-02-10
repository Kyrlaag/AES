using System;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter The Data:");
            var str = Console.ReadLine();
 
            Console.WriteLine("Enter a 32 digit key:");
            var key = Console.ReadLine();

            if (key.Length > 32)
                key = key.Substring(0, 32);

            else if (key.Length < 32)
            {
                for (; key.Length < 32;)
                {
                    key = key + key;

                    if (key.Length > 32)
                    {
                        key = key.Substring(0, 32);
                        break;
                    }
                }
            }

            Console.WriteLine("Used Key=" + key);

            var encodedString = Class1.toEncode(key,str);
            Console.WriteLine("Encoded =" + encodedString);

            var decodedString = Class1.toDecode(key, encodedString);
            Console.WriteLine("Çözülmüş=" + decodedString);

            Console.ReadKey();
        }
    }
}
