namespace _02_A_Miner_Task
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, long> dicCounts = new Dictionary<string, long>();
            string sInput;

            while(true){
                sInput = Console.ReadLine();
                if(sInput == "stop"){
                    break;
                }

                if(! dicCounts.ContainsKey(sInput)){
                    dicCounts.Add(sInput, long.Parse(Console.ReadLine()));
                }
                else{
                    dicCounts[sInput] += long.Parse(Console.ReadLine());
                }

            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            
            foreach(var v in dicCounts){
                Console.WriteLine("{0} -> {1}", v.Key, v.Value);
            }
          
            Console.ResetColor();

        }
    }
}