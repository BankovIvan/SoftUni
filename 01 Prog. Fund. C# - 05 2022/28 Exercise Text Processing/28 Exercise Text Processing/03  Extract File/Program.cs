using System;

namespace _03__Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrFilePath = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);
            string[] arrFileData = arrFilePath[arrFilePath.Length - 1].Split('.');

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("File name: {0}", arrFileData[0]);
            Console.WriteLine("File extension: {0}", arrFileData[1]);
            Console.ResetColor();

        }
    }
}
