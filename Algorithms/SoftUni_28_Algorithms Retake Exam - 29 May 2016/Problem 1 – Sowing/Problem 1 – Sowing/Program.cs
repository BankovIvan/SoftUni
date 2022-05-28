using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    List<string> result = new List<string>();

    static void Main(string[] args)
    {
        int N;
        int[] soil;
        char[] plants;

        N = int.Parse(Console.ReadLine());

        soil = Console.ReadLine().Split().Select(int.Parse).ToArray();
        plants = new char[soil.Length];

        PlantSeedsRecursive(soil, plants, 0, N);

        return;

    }

    private static void PlantSeedsRecursive(int[] soil, char[] plants, int index, int seedsLeft)
    {
        if(index >= soil.Length)
        {
            if(seedsLeft == 0)
            {
                Console.WriteLine(new string(plants));
            }
            return;
        }

        if(soil[index] == 1)
        {
            if (index == 0)
            {
                plants[index] = '.';
                PlantSeedsRecursive(soil, plants, index + 1, seedsLeft - 1);
                plants[index] = '-';
            }
            else if(plants[index - 1] != '.' && seedsLeft > 0)
            {
                plants[index] = '.';
                PlantSeedsRecursive(soil, plants, index + 1, seedsLeft - 1);
                plants[index] = '-';
            }

            plants[index] = '1';
            PlantSeedsRecursive(soil, plants, index + 1, seedsLeft);
            plants[index] = '-';

        }
        else
        {
            plants[index] = '0';
            PlantSeedsRecursive(soil, plants, index + 1, seedsLeft);
        }

        return;
    }
}
