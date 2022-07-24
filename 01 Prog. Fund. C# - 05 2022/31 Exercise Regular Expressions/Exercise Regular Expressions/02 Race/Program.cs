using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"(?<Name>[A-Z|a-z])*(?<Distance>\d)?";
            //Regex regFullName = new Regex(sPattern);
            //Match matchFurniture;
            MatchCollection colRacers;

            string sInput, sName = "";
            int i = 0, nDistance = 0;
            Dictionary<string, int> dicRacers = new Dictionary<string, int>(Console
                                                                            .ReadLine()
                                                                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                                            .Select(x => new KeyValuePair<string, int>(x, 0))
                                                                            );

            while (true)
            {
                sInput = Console.ReadLine();
                if (sInput == "end of race")
                {
                    break;
                }

                colRacers = Regex.Matches(sInput, sPattern);
                sName = "";
                nDistance = 0;

                foreach (Match m in colRacers)
                {
                    foreach(var v in m.Groups["Name"].Captures)
                    {
                        sName += v;
                    }

                    foreach (var v in m.Groups["Distance"].Captures)
                    {
                        nDistance += int.Parse(v.ToString());
                    }

                }

                if(dicRacers.ContainsKey(sName))
                {
                    dicRacers[sName] += nDistance;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v in dicRacers.OrderByDescending(x => x.Value)){
                if(i == 0)
                {
                    Console.WriteLine("1st place: {0}", v.Key);
                }
                else if(i == 1)
                {
                    Console.WriteLine("2nd place: {0}", v.Key);
                }
                else if(i == 2)
                {
                    Console.WriteLine("3rd place: {0}", v.Key);
                }
                else
                {
                    break;
                }

                i++;

            }
            Console.ResetColor();

        }
    }
}
