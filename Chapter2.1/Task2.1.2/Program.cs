using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2._1._2
{
    class Program
    {

        public static double InsertDouble()
        {
            double result;
            bool flag = false;
            do
            {
                flag = Double.TryParse(Console.ReadLine(), out result);

                if (!flag)
                {
                    Console.WriteLine("Некорректный ввод!\n");
                    Console.WriteLine("Попробуйте ещё раз");
                }


            } while (!flag);

            return result;
        }

        public static int InsertInt()
        {
            int result;
            bool flag = false;
            Console.Write("Введите ваш выбор: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out result);

                if (!flag || result < 0)
                {
                    Console.WriteLine("Некорректный ввод!\n");
                    Console.WriteLine("Попробуйте ещё раз");
                }


            } while (!flag);

            return result;
        }

        public static void AppendItem(AbstractFigure figure)
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
            foreach (AbstractFigure o in figures)
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
            Circle
        }

        public static Round CreateRound()
        {
            Console.WriteLine("Создаем круг...");
            Console.Write("Введите центральную точку: ");
            Point center = CreatePoint();
            Console.Write("Введите радиус: ");
            double radius = InsertDouble();

            return new Round(center, radius);
        }

        public static Ring CreateRing()
        {
            Console.WriteLine("Создаем кольцо...");
            Console.Write("Введите центральную точку: ");
            Point center = CreatePoint();
            Console.Write("Введите радиус: ");
            double rad = InsertDouble();
            Console.Write("Введите второй радиус: ");
            double second_rad = InsertDouble();

            return new Ring(center, rad, second_rad);
        }

        public static Point CreatePoint()
        {
            Console.WriteLine("Создаем точку...");
            Console.Write("Введите X: ");
            double x = InsertDouble();
            Console.Write("Введите Y: ");
            double y = InsertDouble();

            return new Point(x, y);
        }

        public static Rectangle CreateRectangle()
        {
            Console.WriteLine("Создаем прямоугольник...");
            Console.WriteLine("Введите левую верхнюю точку: ");
            Point ltp = CreatePoint();
            Console.Write("Введите ширину: ");
            double width = InsertDouble();
            Console.Write("Введите длину: ");
            double height = InsertDouble();

            return new Rectangle(ltp, width, height);
        }

        public static Square CreateSquare()
        {
            Console.WriteLine("Создаем квадрат...");
            Console.WriteLine("Введите левую верхнюю точку: ");
            Point ltp = CreatePoint();
            Console.Write("Введите размер: ");
            double size = InsertDouble();

            return new Square(ltp, size);
        }

        public static Triangle CreateTriangle()
        {
            Console.WriteLine("Создаем треугольник...");
            Console.WriteLine("Введите первую точку ");
            Point first_point = CreatePoint();
            Console.WriteLine("Введите вторую точку ");
            Point second_point = CreatePoint();
            Console.WriteLine("Введите третью точку ");
            Point third_point = CreatePoint();

            return new Triangle(first_point, second_point, third_point);
        }

        public static Line CreateLine()
        {
            Console.WriteLine("Создаем треугольник...");
            Console.WriteLine("Введите первую точку ");
            Point first_point = CreatePoint();
            Console.WriteLine("Введите вторую точку ");
            Point second_point = CreatePoint();

            return new Line(first_point, second_point);
        }

        public static Circle CreateCircle()
        {
            Console.WriteLine("Создаем окружность...");
            Console.Write("Введите центральную точку: ");
            Point center = CreatePoint();
            Console.Write("Введите радиус: ");
            double radius = InsertDouble();

            return new Circle(center, radius);
        }

        public static void PrintTypes()
        {
            for(TypeFigure type = TypeFigure.Round; type <= TypeFigure.Circle; type++)
                Console.WriteLine($"{(int)type}. {type}");
        }

        static List<AbstractFigure> figures = new List<AbstractFigure>();

        public static void SelectFigureForAppend(int choice)
        {
            if(choice < Enum.GetValues(typeof(TypeFigure)).Length)
            {
                switch (choice)
                {
                    case 0:
                        AppendItem(CreateRound());
                        break;
                    case 1:
                        AppendItem(CreateRing());
                        break;
                    case 2:
                        AppendItem(CreateRectangle());
                        break;
                    case 3:
                        AppendItem(CreateSquare());
                        break;
                    case 4:
                        AppendItem(CreateTriangle());
                        break;
                    case 5:
                        AppendItem(CreateLine());
                        break;
                    case 6:
                        AppendItem(CreateCircle());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new Exception("Invalid insert");
            }


        }

        static void Main(string[] args)
        {
            while (true)
            {
                PrintInfo();
                int j = InsertInt();
                if (j < 5)
                {
                    switch (j)
                    {
                        case 1:
                            PrintTypes();
                            SelectFigureForAppend(InsertInt());
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
                    throw new Exception("Invalid insert");
                }
            }
        }
        
    }
}
