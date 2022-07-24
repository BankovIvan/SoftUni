using System;
//using System.Linq;
using System.Text.RegularExpressions;

namespace _03_Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = Console.ReadLine();
            string sPattern = @"\b(?<Day>\d{2})(?<Separator>[\.|\-|/])(?<Month>[A-Z][a-z]{2})\k<Separator>(?<Year>\d{4})\b";

            Regex regFullName = new Regex(sPattern);
            MatchCollection colMatches = regFullName.Matches(sInput);

            foreach(Match m in colMatches)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Day: {0}, Month: {1}, Year: {2}", 
                                        m.Groups["Day"].Value,
                                        m.Groups["Month"].Value,
                                        m.Groups["Year"].Value);
                Console.ResetColor();
            }

        }
    }
}
