namespace _01_Energy_Drinks
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_CAFFEINE = 300;
            const int MIN_CAFFEINE = 0;
            const int TAKE_CAFFEINE = 30;

            int nCurrentCaffeine = MIN_CAFFEINE;

            Stack<int> stackCaffeineContent = new Stack<int>(Array.ConvertAll(
                Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse)));
            Queue<int> queueEnegryDrinks = new Queue<int>(Array.ConvertAll(
                Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse)));
            

            while(stackCaffeineContent.Count > 0 && queueEnegryDrinks.Count > 0)
            {
                int nNextCaffeine = stackCaffeineContent.Pop();
                int nNextDrink = queueEnegryDrinks.Dequeue();
                int nNewCaffeine = nNextCaffeine * nNextDrink + nCurrentCaffeine;

                if(nNewCaffeine <= MAX_CAFFEINE)
                {
                    nCurrentCaffeine = nNewCaffeine;
                }
                else
                {
                    queueEnegryDrinks.Enqueue(nNextDrink);
                    nCurrentCaffeine -= TAKE_CAFFEINE;
                    if(nCurrentCaffeine < MIN_CAFFEINE)
                    {
                        nCurrentCaffeine = MIN_CAFFEINE;
                    }
                }

            } 

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            if(queueEnegryDrinks.Count > 0)
            {
                Console.WriteLine("Drinks left: {0}", string.Join(", ", queueEnegryDrinks));
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine("Stamat is going to sleep with {0} mg caffeine.", nCurrentCaffeine);

            Console.ResetColor();

        }
    }
}
