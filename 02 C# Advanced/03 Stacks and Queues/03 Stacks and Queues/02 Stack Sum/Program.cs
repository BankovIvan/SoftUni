using System;
using System.Collections.Generic;

namespace _02_Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            Stack<int> stackSum = new Stack<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));
            int nSum = 0;

            while (true)
            {
                sCommand = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(sCommand[0] == "end")
                {
                    break;
                }
                else if(sCommand[0] == "add")
                {
                    stackSum.Push(int.Parse(sCommand[1]));
                    stackSum.Push(int.Parse(sCommand[2]));
                }
                else if(sCommand[0] == "remove")
                {
                    int n = int.Parse(sCommand[1]);
                    if(stackSum.Count >= n)
                    {
                        while(n-- > 0)
                        {
                            stackSum.Pop();
                        }
                    }
                }

            }

            foreach(var n in stackSum)
            {
                nSum += n;
            }
            Console.WriteLine("Sum: {0}", nSum);

        }
    }
}
