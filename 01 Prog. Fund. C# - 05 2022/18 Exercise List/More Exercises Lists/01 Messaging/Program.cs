using System;
using System.Collections.Generic;

namespace _01_Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers; // = new List<int>();
            string sText;
            int i, nIndex;

            //lstLessons = new List<string>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries));

            lstNumbers = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));

            sText = Console.ReadLine();

            for(i = 0; i < lstNumbers.Count; i++)
            {
                nIndex = GetNumberDigitsSum(lstNumbers[i]) % sText.Length;
                Console.Write(sText[nIndex]);

                if(nIndex > 0)
                {
                    sText = sText.Substring(0, nIndex) + sText.Substring(nIndex + 1);
                }
                else
                {
                    sText = sText.Substring(1);
                }
                
            }

            Console.WriteLine();

        }

        private static int GetNumberDigitsSum(int nNumber)
        {
            int nRet = 0;

            for(; nNumber > 0; nNumber /= 10)
            {
                nRet += nNumber % 10;
            }

            return nRet;
        }
    }
}
