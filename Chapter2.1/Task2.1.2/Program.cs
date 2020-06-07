using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2._1._2
{
    class Program
    {
        public static void AppendItem(IFigure figure)
        {
            figures.Add(figure);
        }

        public static void PrintInfo()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Добавить фигуру");
            Console.WriteLine("2. Вывести фигуры");
            Console.WriteLine("3. Очистить холст");
            Console.WriteLine("4. Выход");
        }

        public static void PrintFigures()
        {
            Console.WriteLine("Сейчас на холсте: ");
            int count = 0;
            if (figures.Count == 0) Console.WriteLine("Пусто");
            foreach (IFigure o in figures)
            {
                count++;
                Console.Write($"Фигура №{count} : ");
                o.GetInfo();
            }
        }

        enum TypeFigure
        {
            Round,
            Ring,
            Rectangle,
            Square,
            Triangle,
            Line,
            Point,
            Circle
        }

        public static void PrintTypes()
        {
            for(TypeFigure type = TypeFigure.Round; type <= TypeFigure.Circle; type++)
                Console.WriteLine($"{(int)type}. {type}");
        }

        static List<IFigure> figures = new List<IFigure>();

        static void Main(string[] args)
        {
            while (true)
            {
                PrintInfo();
                if (Int32.TryParse(Console.ReadLine(), out int j))
                {
                    switch (j)
                    {
                        case 1:
                            PrintTypes();
                            if (Int32.TryParse(Console.ReadLine(), out int i))
                            {
                                switch (i)
                                {
                                    case 0:
                                        AppendItem(Round.CreateRound());
                                        break;
                                    case 1:
                                        AppendItem(Ring.CreateRing());
                                        break;
                                    case 2:
                                        AppendItem(Rectangle.CreateRectangle());
                                        break;
                                    case 3:
                                        AppendItem(Square.CreateSquare());
                                        break;
                                    case 4:
                                        AppendItem(Triangle.CreateTriangle());
                                        break;
                                    case 5:
                                        AppendItem(Line.CreateLine());
                                        break;
                                    case 6:
                                        AppendItem(Point.CreatePoint());
                                        break;
                                    case 7:
                                        AppendItem(Circle.CreateCircle());
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("String could not be parsed.");
                            }

                            break;
                        case 2:
                            PrintFigures();
                            break;
                        case 3:
                            figures.Clear();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("String could not be parsed.");
                }
            }
        }
        
    }
}
