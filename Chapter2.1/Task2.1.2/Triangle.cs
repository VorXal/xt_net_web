using System;

namespace Task2._1._2
{
    public class Triangle : IFigure
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Point Point3 { get; private set; }
        public Triangle(Point p1, Point p2, Point p3){
            if(p1.Equals(p2) || p1.Equals(p3) || p2.Equals(p3))
            {
                throw new Exception("Invalid points for construct triangle");
            }
            else if(
                Line.GetLength(p1, p2) >= Line.GetLength(p2, p3) + Line.GetLength(p1, p3)   ||
                Line.GetLength(p1, p3) >= Line.GetLength(p1, p2) + Line.GetLength(p2, p3)   ||
                Line.GetLength(p2, p3) >= Line.GetLength(p1, p2) + Line.GetLength(p1, p3)
                )
            {
                throw new Exception("Invalid points for construct triangle");
            }
            else
            {
                Point1 = p1;
                Point2 = p2;
                Point3 = p3;
            }

        }

        public double GetPerimetr()
        {
            return
                Line.GetLength(Point1, Point2) +
                Line.GetLength(Point2, Point3) +
                Line.GetLength(Point3, Point1);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Class:{GetType().Name}, Points: \n\t Point_1:({Point1.X};{Point1.Y}), " +
                $"Point_2:({Point2.X};{Point2.Y}), Point_3:({Point3.X};{Point3.Y})");
        }

        public double GetArea()
        {
            double halfPerimetr = GetPerimetr() / 2;

            return Math.Sqrt(halfPerimetr * (halfPerimetr - Line.GetLength(Point1, Point2)) *
                (halfPerimetr - Line.GetLength(Point2, Point3)) * (halfPerimetr - Line.GetLength(Point1, Point3)));
        }

        public static Triangle CreateTriangle()
        {
            Console.WriteLine("Создаем треугольник...");
            Console.WriteLine("Введите первую точку ");
            Point first_point = Point.CreatePoint();
            Console.WriteLine("Введите вторую точку ");
            Point second_point = Point.CreatePoint();
            Console.WriteLine("Введите третью точку ");
            Point third_point = Point.CreatePoint();
            return new Triangle(first_point, second_point, third_point);
        }
    }
}
