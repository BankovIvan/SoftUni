using System;

namespace _03._EvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNum;

            nNum = int.Parse(Console.ReadLine());

            if(nNum % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
