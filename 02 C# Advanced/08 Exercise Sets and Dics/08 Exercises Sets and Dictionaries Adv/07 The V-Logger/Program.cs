using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> dicFollowers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> dicFollowings = new Dictionary<string, HashSet<string>>();
            string[] arrInput;
            int i = 1;
            string sTheBest;

            while (true)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "Statistics")
                {
                    break;
                }

                if(arrInput[1] == "joined")
                {
                    if (!dicFollowers.ContainsKey(arrInput[0]))
                    {
                        dicFollowers.Add(arrInput[0], new HashSet<string>());
                        dicFollowings.Add(arrInput[0], new HashSet<string>());
                    }
                }
                else if(arrInput[1] == "followed")
                {
                    if(dicFollowers.ContainsKey(arrInput[0]) && 
                        dicFollowers.ContainsKey(arrInput[2]) &&
                        arrInput[0] != arrInput[2])
                    {
                        dicFollowers[arrInput[2]].Add(arrInput[0]);
                        dicFollowings[arrInput[0]].Add(arrInput[2]);
                    }

                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The V-Logger has a total of {0} vloggers in its logs.", dicFollowers.Count);

            foreach(var v1 in dicFollowers.OrderByDescending(x => x.Value.Count).ThenBy(x => dicFollowings[x.Key].Count))
            {
                Console.WriteLine("{0}. {1} : {2} followers, {3} following", i, v1.Key, v1.Value.Count, dicFollowings[v1.Key].Count);
                if(i == 1)
                {
                    foreach(var v2 in dicFollowers[v1.Key].OrderBy(x => x))
                    {
                        Console.WriteLine("*  {0}", v2);
                    }
                }
                i++;
            }

            Console.ResetColor();


        }
    }
}
