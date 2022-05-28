using System;

namespace _10_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nNumber;

            nNumber = int.Parse(Console.ReadLine());

            for(i = 1; i<= 10; i++)
            {
                Console.WriteLine("{0} X {1} = {2}", nNumber, i, nNumber*i);
            }
        }
    }
}
