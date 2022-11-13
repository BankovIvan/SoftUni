namespace _02_Enter_Numbers
{
    using System;
    using System.Transactions;

    internal class Program
    {
        static void Main(string[] args)
        {
            int Countret = 0, start = 1, end = 100;
            int[] output = new int[10];

            while(Countret < 10)
            {
                int result = 0;

                try
                {
                    result = ReadNumber(start, end);
                }
                catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    continue;
                }

                output[Countret++] = result;
                start = result;

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Join(", ", output));
            Console.ResetColor();
        }

        public static int ReadNumber(int start, int end)
        {
            int ret = 0;

            string input = Console.ReadLine();

            if (!int.TryParse(input, out ret))
            {
                throw new ArgumentException("Invalid Number!");
            }

            if(ret <= start || ret >= end)
            {
                throw new ArgumentException(String.Format("Your number is not in range {0} - {1}!", start, end));
            }

            return ret;
        }
    }
}
