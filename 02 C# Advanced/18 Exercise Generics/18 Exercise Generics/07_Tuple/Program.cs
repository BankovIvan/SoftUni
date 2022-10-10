namespace _07_Tuple
{
    using System;
    using System.Xml.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] arrName = new string[arrInput.Length - 1];
            Array.Copy(arrInput, arrName, arrName.Length);
            Tuple<string, string> objTuple1 = new Tuple<string, string>(arrName, new string[] { arrInput[arrInput.Length - 1] });

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> objTuple2 = new Tuple<string, int>(new string[] { arrInput[0] }, new int[] { int.Parse(arrInput[1]) });

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> objTuple3 = new Tuple<int, double>(new int[] { int.Parse(arrInput[0]) }, new double[] { double.Parse(arrInput[1]) });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objTuple1);
            Console.WriteLine(objTuple2);
            Console.WriteLine(objTuple3);
            Console.ResetColor();
        }
    }
}
