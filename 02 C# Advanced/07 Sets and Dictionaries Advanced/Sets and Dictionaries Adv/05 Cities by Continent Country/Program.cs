using System;
using System.Collections.Generic;

namespace _05_Cities_by_Continent_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dicCities = new Dictionary<string, Dictionary<string, List<string>>>();
            int i, nRepeat = int.Parse(Console.ReadLine());
            string[] arrInput;

            for(i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ');

                if (!dicCities.ContainsKey(arrInput[0]))
                {
                    dicCities.Add(arrInput[0], new Dictionary<string, List<string>>());
                }

                if (!dicCities[arrInput[0]].ContainsKey(arrInput[1]))
                {
                    dicCities[arrInput[0]].Add(arrInput[1], new List<string>());
                }

                dicCities[arrInput[0]][arrInput[1]].Add(arrInput[2]);
            }

            foreach(var v1 in dicCities)
            {
                Console.WriteLine("{0}:", v1.Key);
                foreach(var v2 in v1.Value)
                {
                    Console.WriteLine("  {0} -> {1}", v2.Key, string.Join(", ", v2.Value));
                }
            }

        }
    }
}
