using System;

namespace _04_Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSize = int.Parse(Console.ReadLine());
            string sInput;
            char cFind;
            char[,] cSymbols = new char[nSize, nSize];

            for (i = 0; i < nSize; i++)
            {
                sInput = Console.ReadLine();

                for (j = 0; j < nSize; j++)
                {
                    cSymbols[i, j] = sInput[j];
                }
            }

            cFind = Console.ReadLine()[0];

            for (i = 0; i < nSize; i++)
            {
                for (j = 0; j < nSize; j++)
                {
                    if (cSymbols[i, j] == cFind)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("({0}, {1})", i, j);
                        Console.ResetColor();
                        return;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} does not occur in the matrix", cFind);
            Console.ResetColor();

        }
    }
}
