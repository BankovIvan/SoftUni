using System;
using System.Collections.Generic;

namespace _03_Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers = new List<int>();
            List<int> lstTake = new List<int>();
            List<int> lstSkip = new List<int>();
            List<char> lstChars = new List<char>();

            string sText;
            int i, n;
            char[] c = new char[1];

            sText = Console.ReadLine();
            n = 0;

            for (i = 0; i < sText.Length; i++)
            {
                c[0] = sText[i];

                if (int.TryParse(c, out n))
                {
                    lstNumbers.Add(n);
                }
                else
                {
                    lstChars.Add(c[0]);
                }
            }

            for(i = 0; i < lstNumbers.Count; i += 2)
            {
                lstTake.Add(lstNumbers[i]);
            }

            for (i = 1; i < lstNumbers.Count; i += 2)
            {
                lstSkip.Add(lstNumbers[i]);
            }

            sText = "";
            n = 0;

            for (i = 0; i < lstTake.Count; i++)
            {
                if(lstTake[i] > 0)
                {
                    if(n + lstTake[i] >= lstChars.Count)
                    {
                        lstTake[i] = lstChars.Count - n;
                    }
                    sText = sText + new string(lstChars.GetRange(n, lstTake[i]).ToArray());
                    n += lstTake[i];
                }
                n += lstSkip[i];

                if (n >= lstChars.Count)
                {
                    break;
                }
            }

            Console.WriteLine(sText);

        }
    }
}
