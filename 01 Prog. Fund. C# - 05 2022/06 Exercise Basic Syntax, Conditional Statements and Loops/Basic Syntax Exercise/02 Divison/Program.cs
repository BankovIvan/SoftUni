using System;

namespace _02_Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int nGiven;

            nGiven = int.Parse(Console.ReadLine());

            if(nGiven % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (nGiven % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (nGiven % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (nGiven % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (nGiven % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }


        }
    }
}
