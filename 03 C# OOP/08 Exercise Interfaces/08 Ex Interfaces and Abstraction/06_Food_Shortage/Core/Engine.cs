namespace Food.Core
{
    using Food.Core.Interfaces;
    using Food.Models;
    using Food.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] arrInput;
            Dictionary<string, IBuyer> dicBuyers = new Dictionary<string, IBuyer>();

            int nRepeat = int.Parse(Console.ReadLine());
            for(int i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput.Length == 4)
                {
                    Citizen citizen = new Citizen(
                        arrInput[0],
                        int.Parse(arrInput[1]),
                        arrInput[2],
                        DateTime.ParseExact(arrInput[3], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    if (!dicBuyers.ContainsKey(arrInput[0]))
                    {
                        dicBuyers.Add(arrInput[0], citizen);
                    }
                }
                else if(arrInput.Length == 3)
                {
                    Rebel rebel = new Rebel(
                        arrInput[0],
                        int.Parse(arrInput[1]),
                        arrInput[2]);
                    if (!dicBuyers.ContainsKey(arrInput[0]))
                    {
                        dicBuyers.Add(arrInput[0], rebel);
                    }
                }
            }

            string command;
            while((command = Console.ReadLine().Trim()) != "End")
            {
                if (dicBuyers.ContainsKey(command))
                {
                    dicBuyers[command].BuyFood();
                }
            }

            int totalFood = 0;
            foreach (var v in dicBuyers)
            {
                totalFood += v.Value.Food;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(totalFood);
            Console.ResetColor();

        }
    }
}
