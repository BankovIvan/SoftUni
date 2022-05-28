using System;

namespace _03._Numbers_1.N
{
    class Program
    {
        static void Main(string[] args)
        {

            int i, n;

            n = int.Parse(Console.ReadLine());

            for(i=1; i <= n; i += 3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
