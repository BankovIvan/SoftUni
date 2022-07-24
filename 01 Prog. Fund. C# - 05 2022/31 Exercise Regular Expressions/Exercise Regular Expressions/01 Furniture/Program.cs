using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            List<string> lstFurniture = new List<string>();
            double dSum = 0.0;

            string sPattern = @">{2}(?<Furniture>\w+)<{2}(?<Price>\d+\.*\d*)\!(?<Quantity>\d+)\b";
            Regex regFullName = new Regex(sPattern);
            Match matchFurniture;
            //MatchCollection colMatches = regFullName.Matches(sInput);

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "Purchase")
                {
                    break;
                }

                matchFurniture = regFullName.Match(sInput);
                if (matchFurniture.Success == true)
                {
                    lstFurniture.Add(matchFurniture.Groups["Furniture"].Value);
                    dSum += double.Parse(matchFurniture.Groups["Price"].Value) * double.Parse(matchFurniture.Groups["Quantity"].Value);
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bought furniture:");
            Console.WriteLine(String.Join('\n', lstFurniture));
            Console.WriteLine("Total money spend: {0:F2}", dSum);
            Console.ResetColor();

        }
    }
}
