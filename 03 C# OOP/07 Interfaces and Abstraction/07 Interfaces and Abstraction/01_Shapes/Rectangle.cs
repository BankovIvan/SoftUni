namespace Shapes
{
    using System;
    
    public class Rectangle : IDrawable 
    {
        private int width;
        private int height;
        
        public int Width { get {return this.width;} set{this.width = value;} }
        public int Height { get {return this.height;} set {this.height = value;}}

        public Rectangle(int width, int height){
            this.Width = width;
            this.Height = height;
        }

        // TODO: Add fields and a constructor
        public void Draw() 
        { 
            // TODO: implement 
            DrawLine(this.Width, '*', '*');
            for(int i = 2; i < this.Height; i++){
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        } 

        private void DrawLine(int width, char end, char mid){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(end);
            for(int i = 2; i < width; i++){
                Console.Write(mid);
            }
            Console.WriteLine(end);
            Console.ResetColor();
        }
    }

}