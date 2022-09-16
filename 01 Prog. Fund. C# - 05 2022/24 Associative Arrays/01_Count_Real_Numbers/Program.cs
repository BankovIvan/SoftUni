namespace _01_Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> dicCounts = new SortedDictionary<double, int>();
            double[] arrInput;

            arrInput = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), 
                                        new Converter<string, double>(double.Parse));

            foreach(double d in arrInput){
                if(! dicCounts.ContainsKey(d)){
                    dicCounts.Add(d, 1);
                }
                else{
                    dicCounts[d]++;
                }
            }

            foreach(var d in dicCounts){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} -> {1}", d.Key, d.Value);           
                Console.ResetColor();
            }

        }
    }
}