using System;

namespace _05_Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, N, nKey;
            char c;
            string sMessage;

            nKey = int.Parse(Console.ReadLine());
            N = int.Parse(Console.ReadLine());
            sMessage = "";

            for (i = 0; i < N; i++)
            {
                c = char.Parse(Console.ReadLine());
                c = (char)((int)c + nKey);
                sMessage += c;

            }

            Console.WriteLine(sMessage);

        }
    }
}
