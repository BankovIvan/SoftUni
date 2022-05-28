using System;

namespace _06_Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string sCountry;

            sCountry = Console.ReadLine();

            if(sCountry == "USA" || sCountry == "England")
            {
                Console.WriteLine("English");

            }
            else if(sCountry == "Spain" || sCountry == "Argentina" || sCountry == "Mexico")
            {
                Console.WriteLine("Spanish");

            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
