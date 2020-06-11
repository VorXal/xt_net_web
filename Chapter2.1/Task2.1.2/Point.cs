using System;

namespace Task2._1._2
{
    public class Point: AbstractFigure
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Point point = (Point)obj;
            return (this.X == point.X && this.Y == point.Y);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, X:{X}, Y:{Y}");
        }
    }
}
