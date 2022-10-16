namespace _01_Tiles_Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackWhiteTiles;
            Queue<int> queueGreyTiles;

            const int nSinkArea = 40;
            const int nOvenArea = 50;
            const int nCountertopArea = 60;
            const int nWallArea = 70;

            Dictionary<string, int> dicKitchen = new Dictionary<string, int>();

            dicKitchen.Add("Countertop", 0);
            dicKitchen.Add("Floor", 0);
            dicKitchen.Add("Oven", 0);
            dicKitchen.Add("Sink", 0);
            dicKitchen.Add("Wall", 0);

            stackWhiteTiles = new Stack<int>(
                Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));

            queueGreyTiles = new Queue<int>(
                Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));

            while(stackWhiteTiles.Count > 0 && queueGreyTiles.Count > 0){
                int grey = queueGreyTiles.Dequeue();
                int white = stackWhiteTiles.Pop();

                if(grey == white)
                {
                    int tile = grey + white;
                    switch (tile)
                    {
                        case nSinkArea:
                            dicKitchen["Sink"]++;
                            break;  
                        case nOvenArea:
                            dicKitchen["Oven"]++;
                            break;
                        case nCountertopArea:
                            dicKitchen["Countertop"]++;
                            break;
                        case nWallArea:
                            dicKitchen["Wall"]++;
                            break;
                        default:
                            dicKitchen["Floor"]++;
                            break; 

                    }
                }
                else
                {
                    stackWhiteTiles.Push(white / 2);
                    queueGreyTiles.Enqueue(grey);
                }

            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("White tiles left: {0}", 
                stackWhiteTiles.Count > 0 ? string.Join(", ", stackWhiteTiles) : "none" );

            Console.WriteLine("Grey tiles left: {0}", 
                queueGreyTiles.Count > 0 ? string.Join(", ", queueGreyTiles) : "none");

            foreach(var v in dicKitchen.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if(v.Value <= 0)
                {
                    break;
                }
                Console.WriteLine("{0}: {1}", v.Key, v.Value);
            }

            Console.ResetColor();

        }
    }
}
