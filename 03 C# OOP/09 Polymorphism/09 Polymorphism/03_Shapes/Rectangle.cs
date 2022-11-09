namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height { get { return height; } set { height = value; } }
        public double Width { get { return width; } set { width = value; } }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return this.Height + this.Height + this.Width + this.Width;
        }

        public override string Draw()
        {
            StringBuilder ret = new StringBuilder();

            //https://github.com/hammer4/SoftUni/tree/master/C%23%20OOP%20Basics/06.%20Polymorphism%20Lab/03.%20Shapes
            return base.Draw() + this.GetType().Name;

            ret.AppendLine(DrawLine((int)this.Width, '*', '*'));
            for (int i = 1; i < this.height - 1; ++i)
                ret.AppendLine(DrawLine((int)this.width, '*', ' '));
            ret.AppendLine(DrawLine((int)this.width, '*', '*'));

            //DrawLine(this.width, '*', '*');
            //for (int i = 1; i < this.height - 1; ++i)
            //    DrawLine(this.width, '*', ' ');
            //DrawLine(this.width, '*', '*');

            return ret.ToString().Trim();
        }
        private string DrawLine(int width, char end, char mid)
        {
            StringBuilder ret = new StringBuilder();

            ret.Append(end);
            for (int i = 1; i < width - 1; ++i)
                ret.Append(mid);
            ret.Append(end);

            //Console.Write(end);
            //for (int i = 1; i < width - 1; ++i)
            //Console.Write(mid);
            //Console.WriteLine(end);

            return ret.ToString().Trim();
        }


    }
}
