using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace M02_Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"(?<String>[\D]+)(?<Repeat>[\d]+)";
            MatchCollection colMatches;
            string sInput;
            int i, nRepeat;
            StringBuilder sOutput = new StringBuilder();
            //Dictionary<char, int> dicCounts = new Dictionary<char, int>();
            HashSet<char> dicCounts = new HashSet<char>();

            sInput = Console.ReadLine().ToUpper();
            //sMessage = Regex.Replace(sInput, @"\s+", "");

            colMatches = Regex.Matches(sInput, sPattern);
            foreach (Match m in colMatches)
            {
                nRepeat = int.Parse(m.Groups["Repeat"].Value);
                if(nRepeat > 0)
                {
                    foreach (char c in m.Groups["String"].Value)
                    {
                        if (!dicCounts.Contains(c))
                        {
                            dicCounts.Add(c);
                        }
                    }

                    for (i = 0; i < nRepeat; i++)
                    {
                        sOutput.Append(m.Groups["String"].Value);
                    }
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Unique symbols used: {0}", dicCounts.Count);
            Console.WriteLine(sOutput);
            Console.ResetColor();

        }
    }
}
