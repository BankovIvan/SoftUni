using System;
using System.Text.RegularExpressions;

namespace _03_SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPattern = @"%(?<Name>[A-Z][a-z]+)%[^|$%.]*<(?<Product>\w+)>[^|$%.]*\|(?<Count>[0-9]+)\|[^|$%.]*?(?<Price>[0-9]+\.?[0-9]*)\$";
            //Regex regFullName = new Regex(sPattern);
            Match matchOrder;
            double dCurrent = 0.0, dTotal = 0.0;
            string sInput;

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "end of shift")
                {
                    break;
                }

                matchOrder = Regex.Match(sInput, sPattern);
                if (matchOrder.Success)
                {
                    dCurrent = double.Parse(matchOrder.Groups["Count"].Value) * double.Parse(matchOrder.Groups["Price"].Value);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0}: {1} - {2:F2}", matchOrder.Groups["Name"].Value, matchOrder.Groups["Product"].Value, dCurrent);
                    Console.ResetColor();

                    dTotal += dCurrent;
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Total income: {0:F2}", dTotal);
            Console.ResetColor();
        }
    }
}
