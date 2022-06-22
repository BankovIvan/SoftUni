using System;

namespace Problem_1___Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            double dFood, dHay, dCover, dWeight;
            int i, nDay;

            dFood = double.Parse(Console.ReadLine());
            dHay = double.Parse(Console.ReadLine());
            dCover = double.Parse(Console.ReadLine());
            dWeight = double.Parse(Console.ReadLine());

            for(i = 1; i <= 30; i++)
            {
                //Every day Puppy eats 300 gr of food. 
                dFood -= 0.3;

                //Every second day Merry first feeds the pet,
                //then gives it a certain amount of hay equal to 5% of the rest of the food.
                if(i % 2 == 0)
                {
                    dHay -= dFood * 0.05;
                }

                //On every third day, Merry puts Puppy cover with a quantity of 1/3 of its weight.
                if(i % 3 == 0)
                {
                    dCover -= dWeight / 3.0;
                }

                if(Math.Round(dFood, 4) <= 0.0 || Math.Round(dHay, 4) <= 0.0 || Math.Round(dCover, 4) <= 0.0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

            }

            Console.WriteLine("Everything is fine! Puppy is happy! Food: {0:F2}, Hay: {1:F2}, Cover: {2:F2}.", dFood, dHay, dCover);

        }
    }
}
