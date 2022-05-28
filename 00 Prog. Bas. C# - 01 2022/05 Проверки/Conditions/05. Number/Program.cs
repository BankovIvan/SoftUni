using System;

namespace _05._Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNum;

            nNum = int.Parse(Console.ReadLine());

            if(nNum < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (nNum > 200)
            {
                Console.WriteLine("Greater than 200");
            }
            else 
            {
                Console.WriteLine("Between 100 and 200");
            }
        }
    }
}
