using System;

namespace Task2._1._2
{
    public class Round : AbstractCircle, IHasArea
    {
        public Round(Point center, double radius)
            :base(center, radius)
        {
            
        }

        public Round():base(new Point(0,0), 1){        }

        public override double GetCircumference() => 2 * Math.PI * Radius;

        public double GetCircumference(double radius) => 2 * Math.PI * radius;

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, Center: ({Center.X};{Center.Y}), Radius: {Radius}");
        }

        public virtual double GetArea() => Math.PI * Radius * Radius;

        public virtual double GetArea(double radius) => Math.PI * radius * radius;

    }
}
