namespace _05_Play_Catch
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrNumbers = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));
            int numExceptions = 0;

            while (numExceptions < 3)
            {
                string[] arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (arrCommand[0] == "Replace")
                    {
                        arrNumbers[int.Parse(arrCommand[1])] = int.Parse(arrCommand[2]);
                    }
                    else if (arrCommand[0] == "Print")
                    {
                        int startIndex = int.Parse(arrCommand[1]);
                        int endIndex = int.Parse(arrCommand[2]);
                        int[] arrPrint = new int[endIndex - startIndex + 1];
                        Array.Copy(arrNumbers, startIndex, arrPrint, 0, arrPrint.Length);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(String.Join(", ", arrPrint));
                        Console.ResetColor();

                    }
                    else if (arrCommand[0] == "Show")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(arrNumbers[int.Parse(arrCommand[1])]);
                        Console.ResetColor();
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The index does not exist!");
                    Console.ResetColor();
                    numExceptions++;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The variable is not in the correct format!");
                    Console.ResetColor();
                    numExceptions++;
                }
                catch (OverflowException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The variable is not in the correct format!");
                    Console.ResetColor();
                    numExceptions++;
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The index does not exist!");
                    Console.ResetColor();
                    numExceptions++;
                }

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Join(", ", arrNumbers));
            Console.ResetColor();

        }
    }
}
