using System;

namespace _01._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int nAge;

            nAge = int.Parse(Console.ReadLine());

            if(nAge >= 0 && nAge <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (nAge >= 3 && nAge <= 13)
            {
                Console.WriteLine("child");
            }
            else if (nAge >= 14 && nAge <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (nAge >= 20 && nAge <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (nAge >= 66)
            {
                Console.WriteLine("elder");
            }

        }
    }
}
