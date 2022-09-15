using System;
using System.Collections.Generic;

namespace _03_Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stcInput = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<string> stcFormula = new Stack<string>();
            int nResult = 0;

            while(stcInput.Count > 0)
            {
                stcFormula.Push(stcInput.Pop());
            }

            nResult = int.Parse(stcFormula.Pop());
            while(stcFormula.Count > 0)
            {
                if(stcFormula.Pop() == "+")
                {
                    nResult += int.Parse(stcFormula.Pop());
                }
                else
                {
                    nResult -= int.Parse(stcFormula.Pop());
                }
            }

            Console.WriteLine(nResult);

        }
    }
}
