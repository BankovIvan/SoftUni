using System;
using System.Collections.Generic;

namespace _08_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = Console.ReadLine();
            Stack<char> stckParentheses = new Stack<char>();
            char cParenthese;

            foreach (var c in sInput)
            {
                if(c == '(' || c == '[' || c == '{')
                {
                    stckParentheses.Push(c);
                }
                else
                {
                    if(stckParentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        cParenthese = stckParentheses.Pop();

                        if(
                            (c == ')' && cParenthese != '(') || 
                            (c == ']' && cParenthese != '[') || 
                            (c == '}' && cParenthese != '{')
                            ){
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }

            if (stckParentheses.Count == 0)
            {
                Console.WriteLine("YES");
                return;
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }

        }
    }
}
