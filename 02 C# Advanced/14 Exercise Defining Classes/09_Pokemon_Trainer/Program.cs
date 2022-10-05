namespace _09_Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> dicTrainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] arrData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arrData[0] == "Tournament")
                {
                    break;
                }

                if (!dicTrainers.ContainsKey(arrData[0]))
                {
                    dicTrainers.Add(arrData[0], new Trainer(arrData[0], arrData[1], arrData[2], int.Parse(arrData[3])));
                }
                else
                {
                    dicTrainers[arrData[0]].AddPokemon(arrData[1], arrData[2], int.Parse(arrData[3]));
                }

            }

            while (true)
            {
                string sData = Console.ReadLine();
                if (sData == "End")
                {
                    break;
                }

                foreach(var v in dicTrainers)
                {
                    v.Value.Tournament(sData);
                }

            }

            foreach(var v in dicTrainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine("{0} {1} {2}", v.Key, v.Value.Badges, v.Value.Pokemons.Count);
            }

        }
    }
}
