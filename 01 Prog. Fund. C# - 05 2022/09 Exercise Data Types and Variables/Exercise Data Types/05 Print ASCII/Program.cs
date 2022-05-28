using System;

namespace _05_Print_ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int nFirst, nLast;

            nFirst = int.Parse(Console.ReadLine());
            nLast = int.Parse(Console.ReadLine());


            for(;  nFirst <= nLast; nFirst++)
            {
                Console.Write("{0} ", (char)(nFirst));
            }

            Console.WriteLine();

        }
    }
}
