using System;
using System.Linq;
using System.Collections.Generic;

namespace _10_ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dicForces = new Dictionary<string, List<string>>(); //Force, User1-User2-User3-...
            Dictionary<string, string> dicUsers = new Dictionary<string, string>(); //User, Force
            string sInput;
            string[] arrInput;

            while (true)
            {
                sInput = Console.ReadLine();
                arrInput = sInput.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (sInput == "Lumpawaroo")
                {
                    break;
                }

                if(sInput.Contains(" | "))
                {
                    if (!dicUsers.ContainsKey(arrInput[1]))
                    {
                        dicUsers.Add(arrInput[1], arrInput[0]);
                    }
                }
                else if (sInput.Contains(" -> "))
                {
                    if (!dicUsers.ContainsKey(arrInput[0]))
                    {
                        dicUsers.Add(arrInput[0], arrInput[1]);
                    }
                    else
                    {
                        dicUsers[arrInput[0]] = arrInput[1];
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0} joins the {1} side!", arrInput[0], arrInput[1]);
                    Console.ResetColor();

                }

            }

            foreach(var v in dicUsers)
            {
                if (!dicForces.ContainsKey(v.Value))
                {
                    dicForces.Add(v.Value, new List<string>());
                }
                dicForces[v.Value].Add(v.Key);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v1 in dicForces.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                Console.WriteLine("Side: {0}, Members: {1}", v1.Key, v1.Value.Count);
                foreach(var v2 in v1.Value.OrderBy(z => z))
                {
                    Console.WriteLine("! {0}", v2);
                }
            }
            
            Console.ResetColor();

        }
    }
}
