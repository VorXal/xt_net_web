using System;

namespace Task2._1._2
{
    public class Ring : Round, IFigure
    {
        public double SecondRadius { get; private set;}

        public Ring(Point center, double radius, double secondRadius)
            : base(center, radius)
        {
            if (secondRadius < 0) throw new ArgumentException($"SecondRadius can't be negative, was:{secondRadius}");
            else
            {
                SecondRadius = secondRadius;
            }
                
        }


        public override double GetArea()
        {
            if (Radius > SecondRadius)
            {
                return base.GetArea() - GetArea(SecondRadius);
            }
            else
            {
                return GetArea(SecondRadius) - base.GetArea();
            }
        }



        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, Center: ({Center.X};{Center.Y}), First Radius: {Radius}, Second Radius: {SecondRadius}");
        }

        public override double GetCircumference()
        {
            return base.GetCircumference() + GetCircumference(SecondRadius);
        }

        public static Ring CreateRing()
        {
            Console.WriteLine("Создаем кольцо...");
            Console.Write("Введите центральную точку: ");
            Point center = Point.CreatePoint();
            Console.Write("Введите радиус: ");
            double rad = 0;
            if (Double.TryParse(Console.ReadLine(), out double first_radius))
            {
                rad = first_radius;
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }
            Console.Write("Введите второй радиус: ");
            double second_rad = 0;
            if (Double.TryParse(Console.ReadLine(), out double second_radius))
            {
                second_rad = second_radius;
                return new Ring(center, rad, second_rad);
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }
        }

    }
}
