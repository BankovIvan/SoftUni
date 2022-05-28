using System;

namespace _10._Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNumberIn;

            nNumberIn = int.Parse(Console.ReadLine());

            if( ! (nNumberIn == 0 || (nNumberIn >= 100 && nNumberIn <= 200)))
            {
                Console.WriteLine("invalid");
            }


        }
    }
}
