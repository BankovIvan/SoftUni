using System;
using System.Collections.Generic;

namespace _03_Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers1, lstNumbers2, lstResult;
            int i, nListMin = 0;

            lstNumbers1 = new List<int>(Array.ConvertAll(
                                                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, int>(int.Parse)
                                                ));
            lstNumbers2 = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            lstResult = new List<int>();

            if (lstNumbers1.Count < lstNumbers2.Count)
            {
                nListMin = lstNumbers1.Count;
            }
            else
            {
                nListMin = lstNumbers2.Count;
            }

            for(i = 0; i < nListMin; i++)
            {
                lstResult.Add(lstNumbers1[i]);
                lstResult.Add(lstNumbers2[i]);
            }

            if (lstNumbers1.Count < lstNumbers2.Count)
            {
                lstResult.AddRange(GetRemainingElements(lstNumbers2, i));
            }
            else
            {
                lstResult.AddRange(GetRemainingElements(lstNumbers1, i));
            }

            Console.WriteLine(string.Join(" ", lstResult));

        }

        private static List<int> GetRemainingElements(List<int> lstNumbers1, int i)
        {
            List<int> lstRet = new List<int>();

            for(; i < lstNumbers1.Count; i++)
            {
                lstRet.Add(lstNumbers1[i]);
            }

            return lstRet;

        }
    }
}
