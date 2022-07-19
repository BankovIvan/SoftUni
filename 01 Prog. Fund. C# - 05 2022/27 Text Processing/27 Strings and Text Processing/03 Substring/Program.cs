using System;

namespace _03_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string sWord, sSentence;
            int i;

            sWord = Console.ReadLine();
            sSentence = Console.ReadLine();

            while (true)
            {
                i = sSentence.IndexOf(sWord);
                if(i < 0)
                {
                    break;
                }

                sSentence = sSentence.Remove(i, sWord.Length);

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sSentence);
            Console.ResetColor();

        }
    }
}
