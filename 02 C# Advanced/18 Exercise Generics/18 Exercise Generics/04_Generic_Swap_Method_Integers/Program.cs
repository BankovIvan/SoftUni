namespace _04_Generic_Swap_Method_Integers
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lstElements = new List<int>();
            int nRepeat = int.Parse(Console.ReadLine());

            for (int i = 0; i < nRepeat; i++)
            {
                lstElements.Add(int.Parse(Console.ReadLine()));
            }

            string[] arrSwap = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            GenericSwap.SwapElements(lstElements, int.Parse(arrSwap[0]), int.Parse(arrSwap[1]));

            foreach (var v in lstElements)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}: {1}", v.GetType(), v);
                Console.ResetColor();
            }

        }
    }
}
