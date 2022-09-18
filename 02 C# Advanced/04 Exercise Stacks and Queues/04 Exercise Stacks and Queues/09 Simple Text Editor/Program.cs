using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nRepeat, nCurrentCommand;
            StringBuilder sText = new StringBuilder();
            string[] sCommand;
            Stack<string> stckUndoe = new Stack<string>();

            nRepeat = int.Parse(Console.ReadLine());

            for (i = 0; i < nRepeat; i++)
            {
                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                nCurrentCommand = int.Parse(sCommand[0]);

                switch (nCurrentCommand)
                {
                    case 1:
                        AppendString(sText, sCommand[1], stckUndoe);
                        break;

                    case 2:
                        EraseString(sText, int.Parse(sCommand[1]), stckUndoe);
                        break;

                    case 3:
                        PrintElement(sText, int.Parse(sCommand[1]));
                        break;

                    case 4:
                        sText = UndoString(sText, stckUndoe);
                        break;

                    default:

                        break;

                }

            }

        }

        private static StringBuilder UndoString(StringBuilder sText, Stack<string> stckUndoe)
        {
            if(stckUndoe.Count > 0)
            {
                return new StringBuilder(stckUndoe.Pop());
            }

            return sText;
        }

        private static void PrintElement(StringBuilder sText, int nPosition)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(sText[nPosition-1]);
            Console.ResetColor();

        }

        private static void EraseString(StringBuilder sText, int nCount, Stack<string> stckUndoe)
        {
            stckUndoe.Push(sText.ToString());
            sText.Remove(sText.Length - nCount, nCount);
        }

        private static void AppendString(StringBuilder sText, string sAppend, Stack<string> stckUndoe)
        {
            stckUndoe.Push(sText.ToString());
            sText.Append(sAppend);
        }
    }
}
