using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                DisplayMenu();
                switch(InsertValidation.InsertIntRange(1, 3))
                {
                    case 1:
                        new ConsoleUserView();
                        break;
                    case 2:
                        new ConsoleAwardView();
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1) Open UserManager");
            Console.WriteLine("2) Open AwardManager");
            Console.WriteLine("3) Close Program");
        }

    }
}
