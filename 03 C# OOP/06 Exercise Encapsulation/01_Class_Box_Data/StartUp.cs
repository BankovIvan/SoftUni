namespace _01_Class_Box_Data
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Box box;
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try{
                box = new Box(length, width, height);
            }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(box.ToString());
            Console.ResetColor();

        }
    }
}
