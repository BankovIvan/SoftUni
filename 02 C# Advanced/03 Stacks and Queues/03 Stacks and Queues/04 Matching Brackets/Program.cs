using System;
using System.Collections.Generic;

namespace _04_Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stcBrackets = new Stack<int>();
            string sFormula = Console.ReadLine();
            int nStart, nEnd, i;

            for(i = 0; i < sFormula.Length; i++)
            {
                if(sFormula[i] == '(')
                {
                    stcBrackets.Push(i);
                }
                else if (sFormula[i] == ')')
                {
                    nStart = stcBrackets.Pop();
                    Console.WriteLine(sFormula.Substring(nStart, i - nStart + 1));
                }
            }
        }
    }
}
