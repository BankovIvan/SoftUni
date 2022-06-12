using System;

namespace _01_Sign_of_Integer_Numbers
{
    class Program
    {
        static void PrintNumberSign(int i)
        {
            if(i > 0)
            {
                Console.WriteLine("The number {0} is positive.", i);
            }
            else if(i < 0)
            {
                Console.WriteLine("The number {0} is negative.", i);
            }
            else
            {
                Console.WriteLine("The number 0 is zero.");
            }

            return;
        }

        static void Main(string[] args)
        {
            int i;

            i = int.Parse(Console.ReadLine());

            PrintNumberSign(i);

        }
    }
}
