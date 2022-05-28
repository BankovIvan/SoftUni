using System;

namespace _12_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumber;

            nNumber = int.Parse(Console.ReadLine());

            while((nNumber & 1) == 1)
            {
                Console.WriteLine("Please write an even number.");
                nNumber = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("The number is: {0}", Math.Abs(nNumber)) ;
        }
    }
}
