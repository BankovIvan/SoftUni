using System;

namespace _03_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int nFirst, nLast;
            string sCommand;

            sCommand = Console.ReadLine();
            nFirst = int.Parse(Console.ReadLine());
            nLast = int.Parse(Console.ReadLine());

            if (sCommand == "add")
            {
                MyAddAndPrint(nFirst, nLast);
            }
            else if (sCommand == "multiply")
            {
                MyMultiplyAndPrint(nFirst, nLast);
            }
            else if (sCommand == "subtract")
            {
                MySubtractAndPrint(nFirst, nLast);
            }
            else if (sCommand == "divide")
            {
                MyDivideAndPrint(nFirst, nLast);
            }

        }

        private static void MyDivideAndPrint(int nFirst, int nLast)
        {
            Console.WriteLine(nFirst / nLast);
        }

        private static void MySubtractAndPrint(int nFirst, int nLast)
        {
            Console.WriteLine(nFirst - nLast);
        }

        private static void MyMultiplyAndPrint(int nFirst, int nLast)
        {
            Console.WriteLine(nFirst * nLast);
        }

        private static void MyAddAndPrint(int nFirst, int nLast)
        {
            Console.WriteLine(nFirst + nLast);
        }
    }
}
