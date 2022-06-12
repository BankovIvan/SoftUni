using System;

namespace _05_Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNum1, nNum2, nNum3;

            nNum1 = int.Parse(Console.ReadLine());
            nNum2 = int.Parse(Console.ReadLine());
            nNum3 = int.Parse(Console.ReadLine());

            Console.WriteLine(MySubtract(MyAdd(nNum1, nNum2), nNum3));


        }

        private static int MyAdd(int nNum1, int nNum2)
        {
            return nNum1 + nNum2;
        }

        private static int MySubtract(int n, int nNum3)
        {
            return n - nNum3;
        }
    }
}
