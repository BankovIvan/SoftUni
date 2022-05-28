using System;

namespace _02._Numbers_N
{
    class Program
    {
        static void Main(string[] args)
        {

            int i, n;

            i = 0;

            n = int.Parse(Console.ReadLine());

            for(i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }

        }
    }
}
