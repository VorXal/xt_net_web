using System;

namespace Task2._1._2
{
    public class Round : AbstractCircle, IFigure
    {
        public Round(Point center, double radius)
            :base(center, radius)
        {
            
        }

        public Round():base(new Point(0,0), 1){        }

        public override double GetCircumference() => 2 * Math.PI * Radius;

        public double GetCircumference(double radius) => 2 * Math.PI * radius;

        public virtual void GetInfo()
        {
            Console.WriteLine($"Class:{GetType().Name}, Center:({Center.X};{Center.Y}), Radius:{Radius}");
        }

        public virtual double GetArea() => Math.PI * Radius * Radius;

        public virtual double GetArea(double radius) => Math.PI * radius * radius;

        public static Round CreateRound()
        {
            Console.WriteLine("Создаем круг...");
            Console.Write("Введите центральную точку: ");
            Point center = Point.CreatePoint();
            Console.Write("Введите радиус: ");
            if (Double.TryParse(Console.ReadLine(), out double radius))
            {
                return new Round(center, radius);
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }

        }
    }
}
