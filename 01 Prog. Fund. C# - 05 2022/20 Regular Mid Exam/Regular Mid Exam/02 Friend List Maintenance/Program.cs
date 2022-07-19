using System;
using System.Collections.Generic;

namespace _02_Friend_List_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> lstNames;
            string[] arrCommand;
            int nBlacklisted, nLost;

            lstNames = new List<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nBlacklisted = 0;
            nLost = 0;

            while (arrCommand[0] != "Report")
            {

                switch (arrCommand[0])
                {
                    case "Blacklist":
                        nBlacklisted += BlacklistPlayer(lstNames, arrCommand[1]);
                        break;

                    case "Error":
                        nLost += ErrorPlayer(lstNames, int.Parse(arrCommand[1]));
                        break;

                    case "Change":
                        ChangePlayer(lstNames, int.Parse(arrCommand[1]), arrCommand[2]);
                        break;

                    default:

                        break;
                }


                arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Blacklisted names: {0}", nBlacklisted);
            Console.WriteLine("Lost names: {0}", nLost);
            Console.WriteLine(string.Join(' ', lstNames));

        }

        private static void ChangePlayer(List<string> lstNames, int nIndex, string sName)
        {
            if (nIndex < 0 || nIndex >= lstNames.Count)
            {
                return;
            }

            Console.WriteLine("{0} changed his username to {1}.", lstNames[nIndex], sName);
            lstNames[nIndex] = sName;
            return;
        }

        private static int ErrorPlayer(List<string> lstNames, int nIndex)
        {
            if(nIndex < 0 || nIndex >= lstNames.Count)
            {
                return 0;
            }

            if(lstNames[nIndex] != "Blacklisted" && lstNames[nIndex] != "Lost")
            {
                Console.WriteLine("{0} was lost due to an error.", lstNames[nIndex]);
                lstNames[nIndex] = "Lost";
                return 1;
            }

            return 0;
        }

        private static int BlacklistPlayer(List<string> lstNames, string sName)
        {
            if (!lstNames.Contains(sName))
            {
                Console.WriteLine("{0} was not found.", sName);
                return 0;
            }

            lstNames[lstNames.IndexOf(sName)] = "Blacklisted";
            Console.WriteLine("{0} was blacklisted.", sName);
            return 1;

        }
    }
}
