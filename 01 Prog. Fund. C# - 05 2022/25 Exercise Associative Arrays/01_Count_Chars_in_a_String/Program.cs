namespace _01_Count_Chars_in_a_String
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dicCounts = new Dictionary<char, int>();
            string sInput;
            int i;

            sInput = Console.ReadLine();

            for(i = 0; i < sInput.Length; i++){
                if(sInput[i] == ' '){
                    continue;
                }
                else if(! dicCounts.ContainsKey(sInput[i])){
                    dicCounts.Add(sInput[i], 1);
                }
                else{
                    dicCounts[sInput[i]]++;
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