namespace _08_Threeuple
{
    using System;

    internal class Program
    {

        static void Main(string[] args)
        {
            string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] arrCity = new string[arrInput.Length - 3];
            Array.Copy(arrInput, 3, arrCity, 0, arrCity.Length);
            Threeuple<string, string, string> objThreeuple1 = new Threeuple<string, string, string>(
                new string[] { arrInput[0], arrInput[1] }, 
                new string[] { arrInput[2] },
                arrCity);

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, int, bool> objThreeuple2 = new Threeuple<string, int, bool>(
                new string[] { arrInput[0] }, 
                new int[] { int.Parse(arrInput[1]) },
                new bool[] { (arrInput[2] == "drunk") });

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, double, string> objThreeuple3 = new Threeuple<string, double, string>(
                new string[] { arrInput[0] }, 
                new double[] { double.Parse(arrInput[1]) },
                new string[] { arrInput[2] });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objThreeuple1);
            Console.WriteLine(objThreeuple2);
            Console.WriteLine(objThreeuple3);
            Console.ResetColor();
        }
    }
}
