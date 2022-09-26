using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dicContests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> dicUsers = new Dictionary<string, Dictionary<string, int>>();
            string[] arrInput;
            int nPoints;

            while (true)
            {
                arrInput = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "end of contests")
                {
                    break;
                }

                if (!dicContests.ContainsKey(arrInput[0]))
                {
                    dicContests.Add(arrInput[0], arrInput[1]);
                }

            }

            while (true)
            {
                arrInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0] == "end of submissions")
                {
                    break;
                }

                if (!dicContests.ContainsKey(arrInput[0]))
                {
                    continue;
                }

                if (dicContests[arrInput[0]] != arrInput[1])
                {
                    continue;
                }

                nPoints = int.Parse(arrInput[3]);

                if (!dicUsers.ContainsKey(arrInput[2]))
                {
                    dicUsers.Add(arrInput[2], new Dictionary<string, int>(
                        new KeyValuePair<string, int>[] {  new KeyValuePair<string, int>(arrInput[0], nPoints) }  
                        ));
                }
                else
                {
                    if (!dicUsers[arrInput[2]].ContainsKey(arrInput[0]))
                    {
                        dicUsers[arrInput[2]].Add(arrInput[0], nPoints);
                    }
                    else if(dicUsers[arrInput[2]][arrInput[0]] < nPoints)
                    {
                        dicUsers[arrInput[2]][arrInput[0]] = nPoints;
                    }
                }

            }

            string sMaxUser = "";
            int nMaxSum = 0;
            foreach (var v in dicUsers)
            {
                int nCurSum = v.Value.Sum(x => x.Value);
                if(nCurSum > nMaxSum)
                {
                    nMaxSum = nCurSum;
                    sMaxUser = v.Key;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Best candidate is {0} with total {1} points.", sMaxUser, nMaxSum);
            Console.WriteLine("Ranking:");
            foreach(var v1 in dicUsers.OrderBy(x => x.Key))
            {
                Console.WriteLine(v1.Key);
                foreach(var v2 in v1.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", v2.Key, v2.Value);
                }

            }
            Console.ResetColor();

        }
    }
}
