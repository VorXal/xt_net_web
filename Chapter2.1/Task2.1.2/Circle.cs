using System;

namespace Task2._1._2
{
    public class Circle : AbstractCircle, IFigure
    {/*
        public Point Center { get; private set; }
        public double Radius { get; private set; }*/


        public override double GetCircumference() => 2 * Math.PI * Radius;

        public void GetInfo()
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

        public static Circle CreateCircle()
        {
            Console.WriteLine("Создаем окружность...");
            Console.Write("Введите центральную точку: ");
            Point center = Point.CreatePoint();
            Console.Write("Введите радиус: ");
            if (Double.TryParse(Console.ReadLine(), out double radius))
            {
                return new Circle(center, radius);
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }
        }
    }
}
