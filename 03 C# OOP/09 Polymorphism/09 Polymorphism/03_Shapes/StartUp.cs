namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(10.0);
            Shape rectangle = new Rectangle(10.0, 10.0);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Circle Perimeter = {0:F2}", circle.CalculatePerimeter());
            Console.WriteLine("Circle Area = {0:F2}", circle.CalculateArea());
            Console.WriteLine(circle.Draw());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Rectangle Perimeter = {0:F2}", rectangle.CalculatePerimeter());
            Console.WriteLine("Rectangle Area = {0:F2}", rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine();
            Console.ResetColor();

        }
    }
}
