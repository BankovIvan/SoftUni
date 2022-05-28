using System;

namespace _06_Triples_Lett
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k, nNumLetters;

            nNumLetters = int.Parse(Console.ReadLine());

            for(i = 0; i < nNumLetters; i++)
            {
                for(j = 0; j < nNumLetters; j++)
                {
                    for(k = 0; k < nNumLetters; k++)
                    {
                        Console.WriteLine("{0}{1}{2}", (char)('a' + i), (char)('a' + j), (char)('a' + k));

                    }

                }

            }

        }
    }
}
