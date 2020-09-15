using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace ConsolePL
{
    public class ConsoleUserView : IUserPL
    {
        private readonly IUserBLL _userLogic;
        public ConsoleUserView()
        {
            _userLogic = DependencyResolver.DependencyResolver.UserLogic;
            Console.Clear();
            Console.WriteLine("Welcome to UserManager");
            Console.WriteLine("What u want to do?");
            bool flag = true;
            while (flag)
            {
                DisplayMenu();
                switch (InsertValidation.InsertIntRange(1, 6))
                {
                    case 1:
                        CreateNewUser();
                        break;
                    case 2:
                        DisplayUsers();
                        break;
                    case 3:
                        DisplayUserAwards();
                        break;
                    case 4:
                        RemoveUser();
                        break;
                    case 5:
                        AddAward();
                        break;
                    case 6:
                        flag = false;
                        break;
                }
            }
        }
        public void AddAward()
        {
            Console.WriteLine("Insert user id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Insert award id: ");
            string awardId = Console.ReadLine();

            _userLogic.AddAward(id, awardId);
        }

        public void CreateNewUser()
        {
            Console.WriteLine("Insert username:");
            string name = Console.ReadLine();

            DateTime dob;
            do
            {
                Console.WriteLine("Insert Date of Birth");
            }
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dob));

            int age = InsertValidation.InsertIntRange(1, 100);
            _userLogic.AddUser(name, dob, age);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1) Create New User");
            Console.WriteLine("2) Display all users");
            Console.WriteLine("3) Display awards which have this user(need to insert id of award)");
            Console.WriteLine("4) Remove User");
            Console.WriteLine("5) Add award to user");
            Console.WriteLine("6) Go back");
        }

        public void DisplayUserAwards()
        {
            Console.WriteLine("Please insert ID: ");
            string id = Console.ReadLine();

            Console.WriteLine($"User {_userLogic.GetUserByID(id).Name} have awards:");
            foreach(Award a in _userLogic.GetAwards(id))
            {
                Console.WriteLine($"AWARD: {a.Title}");
            }
        }

        public void DisplayUsers()
        {
            Console.WriteLine("USERS:::");
            Console.WriteLine("ID \t\t\t\t\t NAME \t AGE");
            foreach (User u in _userLogic.GetAllUsers())
            {
                Console.WriteLine($"{u.ID} \t {u.Name} \t {u.Age} ");
            }
        }

        public void RemoveUser()
        {
            Console.WriteLine("Please insert ID: ");
            string id = Console.ReadLine();

            _userLogic.RemoveUserByID(id);
        }
    }
}
