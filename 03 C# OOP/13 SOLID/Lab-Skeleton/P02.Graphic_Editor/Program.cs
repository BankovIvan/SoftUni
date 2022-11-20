using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle();
            Square square = new Square();
            Rectangle rect = new Rectangle();

            GraphicEditor editor = new GraphicEditor();

            Console.ForegroundColor = ConsoleColor.Blue;
            editor.DrawShape(circle);
            editor.DrawShape(square);
            editor.DrawShape(rect);
            Console.ResetColor();

        }
    }
}
