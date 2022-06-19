using System;
using System.Collections.Generic;

namespace _09_Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers; // = new List<int>();
            int i, nSum, nIndex, nValue;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));
            nSum = 0;

            while (lstNumbers.Count > 0)
            {
                nIndex = int.Parse(Console.ReadLine());

                if(nIndex < 0)
                {
                    nIndex = 0;
                    nValue = lstNumbers[nIndex];
                    lstNumbers[0] = lstNumbers[lstNumbers.Count-1];
                    //lstNumbers.RemoveAt(lstNumbers.Count - 1);
                }
                else if (nIndex >= lstNumbers.Count)
                {
                    nIndex = lstNumbers.Count - 1;
                    nValue = lstNumbers[nIndex];
                    lstNumbers[nIndex] = lstNumbers[0];
                    //lstNumbers.RemoveAt(0);
                }
                else
                {
                    nValue = lstNumbers[nIndex];
                    lstNumbers.RemoveAt(nIndex);

                }

                nSum += nValue;

                for (i = 0; i < lstNumbers.Count; i++)
                {
                    if(lstNumbers[i] <= nValue)
                    {
                        lstNumbers[i] += nValue;
                    }
                    else
                    {
                        lstNumbers[i] -= nValue;
                    }
                }

            }

            Console.WriteLine(nSum);
        }
    }
}
