using System;
using System.Text;

namespace _04_Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder objText = new StringBuilder(Console.ReadLine());
            int i;

            for(i = 0; i < objText.Length; i++)
            {
                objText.Replace(objText[i], (char)(objText[i] + 3), i, 1);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objText);
            Console.ResetColor();
        }
    }
}
