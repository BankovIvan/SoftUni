namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Circle : Shape
    {
        private double radius;

        public double Radius { get { return radius; } set { radius = value; } }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2.0 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            StringBuilder ret = new StringBuilder();

            //https://github.com/hammer4/SoftUni/tree/master/C%23%20OOP%20Basics/06.%20Polymorphism%20Lab/03.%20Shapes
            return base.Draw() + this.GetType().Name;

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                        ret.Append("*");
                        //Console.Write("*");
                    else
                        ret.Append(" ");
                        //Console.Write(" ");
                }
                ret.AppendLine();
                //Console.WriteLine();
            }


            //double rIn = this.radius - 0.4;
            //double rOut = this.radius + 0.4;
            //for (double y = this.radius; y >= -this.radius; --y)
            //{
                //for (double x = -this.radius; x < rOut; x += 0.5)
                //{
                    //double value = x * x + y * y;
                    //if (value >= rIn * rIn && value <= rOut * rOut)
                        //Console.Write("*");
                   // else
                        //Console.Write(" ");
                //}
                //Console.WriteLine();
            //}

            return ret.ToString().Trim();
        }

    }
}
