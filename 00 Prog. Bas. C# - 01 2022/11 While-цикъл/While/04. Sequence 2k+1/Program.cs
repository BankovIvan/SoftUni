using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int nMax = 0, nNumber = 1;

            nMax = int.Parse(Console.ReadLine());


            while (nNumber <= nMax)
            {
                Console.WriteLine(nNumber);
                nNumber = nNumber * 2 + 1;
            }

        }
    }
}
