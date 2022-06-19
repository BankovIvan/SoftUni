using System;
using System.Collections.Generic;

namespace _08_Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            List<string> lstStrings = new List<string>();
            int nStartIndex, nEndIndex, nIndex, nPartitions;

            lstStrings.AddRange(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nStartIndex = 0;
            nEndIndex = 0;
            nIndex = 0;
            nPartitions = 0;

            while (sCommand[0] != "3:1")
            {
                if(sCommand[0] == "merge")
                {
                    nStartIndex = int.Parse(sCommand[1]);
                    nEndIndex = int.Parse(sCommand[2]);

                    AnonymousMerge(lstStrings, nStartIndex, nEndIndex);

                }
                else if (sCommand[0] == "divide")
                {
                    nIndex = int.Parse(sCommand[1]);
                    nPartitions = int.Parse(sCommand[2]);

                    AnonymousDivide(lstStrings, nIndex, nPartitions);

                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', lstStrings));

        }

        private static void AnonymousDivide(List<string> lstStrings, int nIndex, int nPartitions)
        {
            int i, nPartElements, nChunks;
            string s;
            
            nPartElements = lstStrings[nIndex].Length / nPartitions;
            s = lstStrings[nIndex];
            nChunks = nPartitions - 1;

            lstStrings.RemoveAt(nIndex);

            for (i = 0; i < nChunks; i++)
            {
                lstStrings.Insert(nIndex, s.Substring(i*nPartElements, nPartElements));
                nIndex++;
            }
            //remaining characters to the end of the string;
            lstStrings.Insert(nIndex, s.Substring(i*nPartElements));

        }

        private static void AnonymousMerge(List<string> lstStrings, int nStartIndex, int nEndIndex)
        {
            int i;

            if(nStartIndex < 0)
            {
                nStartIndex = 0;
            }
            else if (nStartIndex >= lstStrings.Count)
            {
                return;
            }

            if(nEndIndex >= lstStrings.Count)
            {
                nEndIndex = lstStrings.Count - 1;
            }
            else if(nEndIndex <= nStartIndex)
            {
                return;
            }

            for (i = nStartIndex+1; i <= nEndIndex; i++)
            {
                lstStrings[nStartIndex] += lstStrings[i];
            }

            lstStrings.RemoveRange(nStartIndex + 1, nEndIndex - nStartIndex);

        }
    }
}
