using System;

namespace _08_Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string sTownName;
            int nPopulation;
            decimal decArea;

            sTownName = Console.ReadLine();
            nPopulation = int.Parse(Console.ReadLine());
            decArea = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Town {0} has population of {1} and area {2} square km.", sTownName, nPopulation, decArea);

        }
    }
}
