using System;
using System.Collections.Generic;

namespace _04_Mixed_Up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers1; // = new List<int>();
            List<int> lstNumbers2; // = new List<int>();
            List<int> lstCombined = new List<int>();
            int i, nCount=0, nMax=0, nMin=0;

            lstNumbers1 = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));

            lstNumbers2 = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));

            if(lstNumbers1.Count > lstNumbers2.Count)
            {
                nCount = lstNumbers2.Count;
            }
            else
            {
                nCount = lstNumbers1.Count;
            }

            for(i = 0; i < nCount; i++)
            {
                lstCombined.Add(lstNumbers1[0]);
                lstNumbers1.RemoveAt(0);
                lstCombined.Add(lstNumbers2[lstNumbers2.Count-1]);
                lstNumbers2.RemoveAt(lstNumbers2.Count - 1);
            }

            if(lstNumbers1.Count > 1)
            {
                nMax = Math.Max(lstNumbers1[0], lstNumbers1[1]);
                nMin = Math.Min(lstNumbers1[0], lstNumbers1[1]);
            }
            else
            {
                nMax = Math.Max(lstNumbers2[0], lstNumbers2[1]);
                nMin = Math.Min(lstNumbers2[0], lstNumbers2[1]);
            }

            for(i = 0; i < lstCombined.Count; i++)
            {
                if(lstCombined[i] <= nMin || lstCombined[i] >= nMax)
                {
                    lstCombined.RemoveAt(i);
                    i--;
                }
            }

            lstCombined.Sort();

            Console.WriteLine(string.Join(' ', lstCombined));

        }
    }
}
