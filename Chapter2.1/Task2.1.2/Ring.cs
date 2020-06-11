using System;

namespace Task2._1._2
{
    public class Ring : Round
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

    }
}
