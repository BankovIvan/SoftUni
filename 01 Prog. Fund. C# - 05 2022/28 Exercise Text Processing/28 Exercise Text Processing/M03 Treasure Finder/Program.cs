using System;
using System.Collections.Generic;

namespace M03_Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {

            string sData, sMessage, sTreasure, sLocation;
            int i, j, k, nStart, nCount, nRepeat;
            List<int> lstChipher;

            lstChipher = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));

            while (true)
            {
                sData = Console.ReadLine();
                if(sData == "find")
                {
                    break;
                }

                sTreasure = "";
                sLocation = "";
                nStart = 0;
                nCount = -1;
                k = 0;
                sMessage = "";

                for (j = 0; j < sData.Length; j++)
                {
                    sMessage = sMessage + (char)(sData[j] - lstChipher[k]);

                    k++;
                    if (k >= lstChipher.Count)
                    {
                        k = 0;
                    }
                }
                 
                for (j = 0; j < sData.Length; j++)
                {

                    if (sMessage[j] == '&')
                    {
                        if(nCount == -1)
                        {
                            nStart = j;
                            nCount = 0;
                        }
                        else
                        {
                            nCount = j - nStart;
                            sTreasure = sMessage.Substring(nStart + 1, nCount - 1);
                            nCount = -1;
                        }
                    }
                    else if (sMessage[j] == '<')
                    {
                        nStart = j;
                    }
                    else if (sMessage[j] == '>')
                    {
                        nCount = j - nStart;
                        sLocation = sMessage.Substring(nStart + 1, nCount - 1);
                    }

                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Found {0} at {1}", sTreasure, sLocation);
                Console.ResetColor();

            }
        }
    }
}
