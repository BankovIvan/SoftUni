using System;

namespace _03_Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrNumbers;
            double d;

            arrNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(string s in arrNumbers)
            {
                d = double.Parse(s);
                Console.WriteLine("{0} => {1}", d, (int)Math.Round(d, MidpointRounding.AwayFromZero));
            }

        }
    }
}
