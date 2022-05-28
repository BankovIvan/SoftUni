using System;

namespace _01_Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2, n3, n4, nResult;

            n1 = int.Parse(Console.ReadLine());
            n2 = int.Parse(Console.ReadLine());
            n3 = int.Parse(Console.ReadLine());
            n4 = int.Parse(Console.ReadLine());

            nResult = n1 + n2;
            nResult /= n3;
            nResult *= n4;

            Console.WriteLine(nResult);

        }
    }
}
