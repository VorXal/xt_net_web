using System;

namespace Task2._1._2
{
    public abstract class AbstractCircle
    {
        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public AbstractCircle(Point center, double radius)
        {
            if (radius < 0) throw new ArgumentException($"Radius can't be negative, was:{radius}");
            else
            {
                Center = center;
                Radius = radius;
            }
        }
        public abstract double GetCircumference();

    }
}
