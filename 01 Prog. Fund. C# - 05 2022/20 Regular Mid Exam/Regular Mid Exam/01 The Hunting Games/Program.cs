using System;

namespace _01_The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nDays, nPlayers;
            double dEnergy, dWater, dFood, dLoss;

            nDays = int.Parse(Console.ReadLine());
            nPlayers = int.Parse(Console.ReadLine());
            dEnergy = double.Parse(Console.ReadLine());
            dWater = double.Parse(Console.ReadLine());
            dFood = double.Parse(Console.ReadLine());

            dWater *= nDays * nPlayers;
            dFood *= nDays * nPlayers;

            for (i = 1; i <= nDays; i++)
            {
                dLoss = double.Parse(Console.ReadLine());

                dEnergy -= dLoss;
                if(dEnergy <= 0)
                {
                    Console.WriteLine("You will run out of energy. You will be left with {0:F2} food and {1:F2} water.", dFood, dWater);
                    return;
                }

                if(i % 2 == 0)
                {
                    dEnergy *= 1.05;
                    dWater *= 0.70;
                }

                if (i % 3 == 0)
                {
                    dEnergy *= 1.10;
                    dFood -= dFood/nPlayers;
                }

            }

            Console.WriteLine("You are ready for the quest. You will be left with - {0:F2} energy!", dEnergy);
        }
    }
}
