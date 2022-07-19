using System;

namespace _01_Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrWords;
            Random objRnd = new Random();
            int i, j;
            string sSwap;

            arrWords = Console.ReadLine().Split(' ');

            for (i = 0; i < arrWords.Length; i++)
            {
                j = objRnd.Next(arrWords.Length);
                sSwap = arrWords[i];
                arrWords[i] = arrWords[j];
                arrWords[j] = sSwap;
            }

            Console.WriteLine(string.Join('\n', arrWords));

        }
    }
}