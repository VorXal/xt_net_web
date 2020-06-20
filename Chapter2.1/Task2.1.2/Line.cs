using System;

namespace Task2._1._2
{
    public class Line : AbstractFigure
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        public Line(Point p1, Point p2)
        {
            this.Point1 = p1;
            this.Point2 = p2;
        }

        public double GetLength() => Math.Sqrt((Point1.X - Point2.X) * (Point1.X - Point2.X) + (Point1.Y - Point2.Y) * (Point1.Y - Point2.Y));

        public static double GetLength(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, Point_1: ({Point1.X};{Point1.Y}), Point_2: ({Point2.X};{Point2.Y})");
        }

    }
}
