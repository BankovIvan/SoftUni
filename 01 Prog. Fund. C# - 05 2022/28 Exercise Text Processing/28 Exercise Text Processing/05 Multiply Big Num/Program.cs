using System;
using System.Collections.Generic;

namespace _05_Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string sBigNumber;
            List<char> lstBigResult = new List<char>();
            int i, nMultiplier, nDigit, nProduct, nRemainder;

            sBigNumber = Console.ReadLine();
            nMultiplier = int.Parse(Console.ReadLine());
            nRemainder = 0;

            if(sBigNumber == "0" || nMultiplier == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("0");
                Console.ResetColor();
                return;
            }

            for (i = sBigNumber.Length - 1; i >= 0; i--)
            {
                nProduct = ((int)(sBigNumber[i] - '0') * nMultiplier) + nRemainder;
                nRemainder = nProduct / 10;
                nDigit = nProduct % 10;
                lstBigResult.Add((char)(nDigit + '0'));
            }

            if(nRemainder > 0)
            {
                lstBigResult.Add((char)(nRemainder + '0'));
            }

            lstBigResult.Reverse();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(lstBigResult.ToArray());
            Console.ResetColor();
        }
    }
}
