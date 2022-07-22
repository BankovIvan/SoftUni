using System;
using System.Text;

namespace M05_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            StringBuilder sOutput = new StringBuilder();

            sOutput.Append("<h1>");
            sOutput.AppendLine();
            sOutput.Append("    ");
            sOutput.Append(Console.ReadLine());
            sOutput.AppendLine();
            sOutput.Append("</h1>");
            sOutput.AppendLine();

            sOutput.Append("<article>");
            sOutput.AppendLine();
            sOutput.Append("    ");
            sOutput.Append(Console.ReadLine());
            sOutput.AppendLine();
            sOutput.Append("</article>");
            sOutput.AppendLine();

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "end of comments")
                {
                    break;
                }

                sOutput.Append("<div>");
                sOutput.AppendLine();
                sOutput.Append("    ");
                sOutput.Append(sInput);
                sOutput.AppendLine();
                sOutput.Append("</div>");
                sOutput.AppendLine();

            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sOutput);
            Console.ResetColor();
        }
    }
}
