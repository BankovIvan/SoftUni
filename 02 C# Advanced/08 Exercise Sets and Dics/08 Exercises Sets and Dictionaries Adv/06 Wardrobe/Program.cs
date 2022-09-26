using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dicWardrobe = new Dictionary<string, Dictionary<string, int>>();
            int i, j, nRepeat = int.Parse(Console.ReadLine());
            string[] arrInput;

            for(i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                if(!dicWardrobe.ContainsKey(arrInput[0]))
                {
                    dicWardrobe.Add(arrInput[0], new Dictionary<string, int>());
                }

                for(j = 1; j < arrInput.Length; j++)
                {
                    if (!dicWardrobe[arrInput[0]].ContainsKey(arrInput[j]))
                    {
                        dicWardrobe[arrInput[0]].Add(arrInput[j], 1);
                    }
                    else
                    {
                        dicWardrobe[arrInput[0]][arrInput[j]]++;
                    }
                }
            }

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (dicWardrobe.ContainsKey(arrInput[0]))
            {
                if (dicWardrobe[arrInput[0]].ContainsKey(arrInput[1]))
                {
                    dicWardrobe[arrInput[0]][arrInput[1]] *= -1;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v1 in dicWardrobe)
            {
                Console.WriteLine("{0} clothes:", v1.Key);
                foreach(var v2 in v1.Value)
                {
                    if(v2.Value < 0)
                    {
                        Console.WriteLine("* {0} - {1} (found!)", v2.Key, v2.Value * -1);
                    }
                    else
                    {
                        Console.WriteLine("* {0} - {1}", v2.Key, v2.Value);
                    }
                }
            }
            Console.ResetColor();
        }
    }
}
