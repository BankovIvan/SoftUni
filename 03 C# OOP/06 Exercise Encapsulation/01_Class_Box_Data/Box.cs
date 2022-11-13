namespace _01_Class_Box_Data
{
    using System;
    using System.Text;

    public class Box
    {
        private readonly double length;
        private readonly double width;
        private readonly double height;

        public double Length { get => this.length; }
        public double Width { get => this.width; }
        public double Height { get => this.height; }

        public Box(double length, double width, double height){

            if(length <= 0.0) throw new ArgumentException("Length cannot be zero or negative.");
            if(width <= 0.0) throw new ArgumentException("Width cannot be zero or negative.");
            if(height <= 0.0) throw new ArgumentException("Height cannot be zero or negative.");

            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double SurfaceArea(){
            return 2.0 * this.length * this.width +
                    2.0 * this.length * this.height + 
                    2.0 * this.width * this.height;
        }

        public double LateralSurfaceArea(){
            return 2.0 * this.length * this.height + 
                    2.0 * this.width * this.height;
        }

        public double Volume(){
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Surface Area - {0:F2}", this.SurfaceArea()));
            ret.AppendLine(String.Format("Lateral Surface Area - {0:F2}", this.LateralSurfaceArea()));
            ret.AppendLine(String.Format("Volume - {0:F2}", this.Volume()));

            return ret.ToString().Trim();
        }
    }
}