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
    public class ConsoleAwardView : IAwardPL
    {
        public ConsoleAwardView()
        {
            Console.Clear();
            Console.WriteLine("Welcome to AwardManager");
            Console.WriteLine("What u want to do?");
            bool flag = true;
            while (flag)
            {
                DisplayMenu();
                switch (InsertValidation.InsertIntRange(1, 6))
                {
                    case 1:
                        CreateNewAward();
                        break;
                    case 2:
                        DisplayAwards();
                        break;
                    case 3:
                        DisplayAwardUsers();
                        break;
                    case 4:
                        RemoveAward();
                        break;
                    case 5:
                        AddUser();
                        break;
                    case 6:
                        flag = false;
                        break;
                }
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1) Create New Award");
            Console.WriteLine("2) Display all awards");
            Console.WriteLine("3) Display users which have this award(need to insert id of award)");
            Console.WriteLine("4) Remove Award");
            Console.WriteLine("5) Add user to award");
            Console.WriteLine("6) Go back");
        }

        public void CreateNewAward()
        {
            Console.WriteLine("Please insert title for create new award");
            string title = Console.ReadLine();
            //validation title and bla-bla-bla if it's okay:
            new AwardManager().AddAward(title);
        }

        public void DisplayAwards()
        {
            Console.WriteLine("AWARDS:::");
            foreach (Award a in new AwardManager().GetAllAwards())
            {
                Console.WriteLine(a.ID + "\t" + a.Title);
            }
            Console.WriteLine();
        }

        public void DisplayAwardUsers()
        {
            Console.WriteLine("Please insert ID: ");
            string id = Console.ReadLine();

            Console.WriteLine($"Users which have award: {new AwardManager().GetAwardByID(id).Title}");

            foreach (User user in new AwardManager().GetUsers(id))
            {
                Console.WriteLine("USER");
                Console.WriteLine($"ID: "  + user.ID);
                Console.WriteLine($"Name: " + user.Name);
            }
            Console.WriteLine();
        }

        public void RemoveAward()
        {
            Console.WriteLine("Please insert ID: ");
            string id = Console.ReadLine();

            new AwardManager().RemoveAwardByID(id);
        }

        public void AddUser()
        {
            Console.WriteLine("Please insert award ID: ");
            string awardId = Console.ReadLine();
            Console.WriteLine("Please insert user ID:");
            string userId = Console.ReadLine();
            new AwardManager().AddUser(awardId, userId);
        }
    }
}
