using System;
using System.Collections.Generic;

namespace _03_Maximum_and_Minimum_El
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stcNumbers = new Stack<int>();
            int nRepeat, i;
            int[] arrInput;

            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++)
            {
                arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)
                                            );

                switch (arrInput[0])
                {
                    case 1:
                        PushNumber(stcNumbers, arrInput[1]);
                        break;

                    case 2:
                        DeleteNumber(stcNumbers);
                        break;

                    case 3:
                        PrintMaxNumber(stcNumbers);
                        break;

                    case 4:
                        PrintMinNumber(stcNumbers);
                        break;

                    default:

                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Join(", ", stcNumbers.ToArray()));
            Console.ResetColor();

        }

        private static void PushNumber(Stack<int> stc, int n)
        {
            stc.Push(n);
            return;
        }

        private static void DeleteNumber(Stack<int> stc)
        {
            if(stc.Count > 0)
            {
                stc.Pop();
            }
            
            return;
        }

        private static void PrintMaxNumber(Stack<int> stc)
        {
            int nMax = int.MinValue;

            if(stc.Count == 0)
            {
                return;
            }

            foreach(var v in stc)
            {
                if(nMax < v)
                {
                    nMax = v;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nMax);
            Console.ResetColor();
            return;

        }

        private static void PrintMinNumber(Stack<int> stc)
        {
            int nMin = int.MaxValue;

            if (stc.Count == 0)
            {
                return;
            }

            foreach (var v in stc)
            {
                if (nMin > v)
                {
                    nMin = v;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nMin);
            Console.ResetColor();
            return;
        }

    }
}
