using System;

namespace _02_Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;

            n = int.Parse(Console.ReadLine());

            string[] s = new string[n];

            for(i = n - 1; i >= 0; i--)
            {
                s[i] = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', s));

        }
    }
}
