using System;

namespace Task2._1._2
{
    public class Circle : AbstractCircle
    { 
        public override double GetCircumference() => 2 * Math.PI * Radius;

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, Center: ({Center.X};{Center.Y}), Radius: {Radius}");
        }

        public double GetArea()
        {
            throw new Exception("Circle haven't area");
        }

        public Circle():base(new Point(0,0), 1) { }

        public Circle(Point center, double radius):
            base(center, radius){ }

    }
}
