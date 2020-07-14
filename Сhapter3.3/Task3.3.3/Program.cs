using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._3
{
    class Program
    {
        static int id = 0;

        private static int GetNewId() => id++;

        public static int InsertIntRange(int min, int max)
        {
            int result;
            bool flag = false;
            Console.Write("Your select: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out result);

                if (!flag || result < min || result > max)
                {
                    Console.WriteLine("Incorrect insert\n");
                    Console.WriteLine("Try one more time");
                    flag = false;
                }
                
            } while (!flag);

            return result;
        }

        public static int InsertPositiveInt()
        {
            int result;
            bool flag = false;
            Console.Write("Your select: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out result);

                if (!flag || result < 0)
                {
                    Console.WriteLine("Incorrect insert\n");
                    Console.WriteLine("Try one more time");
                    flag = false;
                }

            } while (!flag);

            return result;
        }

        private static void PrintMainMenu(Pizzeria pizzeria)
        {
            Console.Clear();
            Console.WriteLine("Welcome to EPAMIZZA, my friend!");
            Console.WriteLine("You can continue like: ");
            Console.WriteLine("1) Client");
            Console.WriteLine("2) Admin(or employee)");
            switch (InsertIntRange(1,2))
            {
                case 1:
                    PrintClientMenu(pizzeria);
                    break;
                case 2:
                    PrintAdminMenu(pizzeria);
                    break;
                default:
                    break;
            }
        }

        private static void PrintAdminMenu(Pizzeria pizzeria)
        {
            Console.Clear();
            PrintOrders(pizzeria);
            Console.WriteLine("Select order for change status. ");
            int choose = InsertPositiveInt();
            Order selectedOrder = null;
            while (true)
            {
                foreach (var item in pizzeria.Orders)
                {
                    if (item.GetId() == choose)
                    {
                        selectedOrder = item;
                    }
                }
                if (selectedOrder != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again");
                    PrintOrders(pizzeria);
                    choose = InsertPositiveInt();
                }
            }
            if(selectedOrder.GetStatusOrder() == StatusOrder.Cooking)
            {
                pizzeria.ReadyOrder(selectedOrder);
            }
            else if(selectedOrder.GetStatusOrder() == StatusOrder.Done)
            {
                pizzeria.FinishOrder(selectedOrder);
            }

            Console.WriteLine("Press any key for go to main menu");
            PrintMainMenu(pizzeria);
        }

        private static void PrintClientMenu(Pizzeria pizzeria)
        {
            Console.Clear();

            Console.WriteLine("You can: ");
            Console.WriteLine("1) Make an order");
            Console.WriteLine("2) Check status of orders");
            Console.WriteLine("3) Go back");

            switch (InsertIntRange(1, 3))
            {
                case 1:
                    pizzeria.AddOrder(CreateOrder());
                    PrintClientMenu(pizzeria);
                    break;
                case 2:
                    PrintOrders(pizzeria);
                    PrintClientMenu(pizzeria);
                    break;
                case 3:
                    PrintMainMenu(pizzeria);
                    break;
                default:
                    break;
            }

        }

        private static void PrintOrders(Pizzeria pizzeria)
        {
            Console.Clear();
            pizzeria.PrintOrders();
            Console.WriteLine("Press any key for continue...");
            Console.ReadKey();
        }

        private static Order CreateOrder()
        {
            Console.Clear();
            Console.Write("Your name please: ");
            string name = Console.ReadLine();
            Console.WriteLine($"How many pizza's you want?\t (from 1 to {Enum.GetValues(typeof(TypePizza)).Length}) ((not recommend to insert 0))");
            int count = InsertIntRange(0, Enum.GetValues(typeof(TypePizza)).Length);
            if(count == 0)
            {
                
                while (true) { Console.WriteLine("Bye-bye"); }
            }
            Console.WriteLine("Choose your pizza");
            List<int> typePizzas = new List<int>();
            int i = 0;
            int choose = 0;
            while (i < count)
            {
                i++;
                for (int j = 0; j < Enum.GetValues(typeof(TypePizza)).Length; j++)
                {
                    Console.WriteLine($"{j}) {(TypePizza)j}");
                }
                choose = InsertIntRange(-1, Enum.GetValues(typeof(TypePizza)).Length - 1);
                if(choose == -1)
                {
                    break;
                }
                typePizzas.Add(choose);
                Console.WriteLine($"We add pizza \"{(TypePizza)choose}\" to your order");
            }
            List<Pizza> pizzas = new List<Pizza>();
            foreach (var item in typePizzas)
            {
                pizzas.Add(new Pizza((TypePizza)item));
            }

            Order thisOrder = new Order(GetNewId(), name, pizzas.ToArray());
            Console.WriteLine(thisOrder.ToString());
            Console.WriteLine("Press some key for go to main menu");
            Console.ReadKey();
            return thisOrder;
        }

        

        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria();

            PrintMainMenu(pizzeria);
            //PrintAdminMenu(pizzeria);
            Console.ReadKey();
        }
    }
}
