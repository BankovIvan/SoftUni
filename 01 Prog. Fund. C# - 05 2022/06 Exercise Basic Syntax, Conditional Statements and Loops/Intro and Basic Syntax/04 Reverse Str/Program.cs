using System;

namespace _04_Reverse_Str
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int i;

            s = Console.ReadLine();

            for(i = s.Length-1; i>=0; i--)
            {
                Console.Write(s[i]);
            }

            Console.WriteLine();

        }
    }
}
