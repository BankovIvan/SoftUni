namespace _04_Sum_of_Integers
{
    using System;
    using System.Globalization;

    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            string[] arrInput = Console.ReadLine().Split(' '/*, StringSplitOptions.RemoveEmptyEntries*/);

            foreach(string v in arrInput)
            {
                try
                {
                    //sum = AddInteger(v, sum);

                    sum += int.Parse(v);
                }
                catch(FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The element '{0}' is in wrong format!", v);
                    Console.ResetColor();
                }
                catch (OverflowException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The element '{0}' is out of range!", v);
                    Console.ResetColor();
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Element '{0}' processed - current sum: {1}", v, sum);
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The total sum of all integers is: {0}", sum);
            Console.ResetColor();

        }

        public static int AddInteger(string value, int sum)
        {
            int ret = sum;

            //int data = Convert.ToInt32(value);
            //
            //ret = sum + data;

            ret = sum + int.Parse(value);

            return ret;
        } 

    }
}
