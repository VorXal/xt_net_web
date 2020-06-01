using System;

namespace Task2._1._2
{
    public class Circle : Figure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public Circle() { }

        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {this.GetType().Name}, Center: ({X};{Y}), Radius: {Radius}");
        }



    }
}
