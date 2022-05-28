using System;

namespace _08_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nLength;

            nLength = int.Parse(Console.ReadLine());

            for(i = 1; i <= nLength; i++)
            {

                Console.Write(i);

                for(j = i; j > 1; j--)
                {
                    Console.Write(" {0}", i);

                }

                Console.WriteLine();
            }

        }
    }
}
