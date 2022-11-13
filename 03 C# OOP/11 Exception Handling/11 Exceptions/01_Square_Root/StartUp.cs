namespace SquareRoot
{
    //using SquareRoot.Core;
    //using SquareRoot.Core.Interfaces;
    //using SquareRoot.Exceptions;
    //using SquareRoot.IO;
    //using SquareRoot.IO.Interfaces;
    using System;

    internal class StartUp
    {

        public static double Sqrt(double value)
        {
            if (value < 0)
                //throw new System.ArgumentOutOfRangeException("value", "Invalid number.");
                throw new System.ArgumentException("Invalid number.");
            return Math.Sqrt(value);
        }

        static void Main()
        {
            double data = double.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(Sqrt(data));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }

            Console.WriteLine("Goodbye.");
        }

        /*
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            try
            {
                engine.Run();
            }
            catch(SquareRootFromNegativeNumberException ex)
            {
                writer.WriteLine(ex.Message);
            }

            writer.WriteLine("Goodbye.");

        }
        */
    }
}
