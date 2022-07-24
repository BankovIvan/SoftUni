using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02_Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            string sInput = Console.ReadLine();
            string sPattern = @"\+359(?<Separator>[ |-])2\k<Separator>(?<Number>\d{3}\k<Separator>\d{4})\b";

            Regex regFullName = new Regex(sPattern);
            MatchCollection colMatches = regFullName.Matches(sInput);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Join(", ", colMatches.Select(x => x.Value).ToArray()));
            Console.ResetColor();
        }
    }
}
