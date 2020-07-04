using System;
using System.Collections.Generic;

namespace Task3._1._1
{
    class Program
    {
        public static void GetInfo(List<Person> people, int round)
        {
            Console.WriteLine($"Round: {round}");
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static int CountLosers(List<Person> people)
        {
            int count = 0;
            foreach (Person p in people)
            {
                if (!p.Winner)
                    count++;
            }
            return count;
        }

        public static void NormalizeIndex(List<Person> people, ref int index)
        {
            while(index > people.Count - 1)
            {
                index -= people.Count;
            }
        }

        public static int FindNextLoserIndex(List<Person> people, int index, int step)
        {
            bool flag = true;
            int count = 0;
            while (flag)
            {
                index++;
                if (index > people.Count - 1)
                {
                    NormalizeIndex(people, ref index);
                }
                if (people[index].Winner)
                {
                    count++;
                }
                if (count == step)
                {
                    flag = false;
                }
            }
            return index;
        }

        public static void Menu(List<Person> people, int step)
        {
            Console.Clear();
            Console.WriteLine("What u want?");
            Console.WriteLine("1. Append people");
            Console.WriteLine("2. Start searching winner");
            Console.Write("Your choose: ");
            Int32.TryParse(Console.ReadLine(), out int choose);
            switch (choose)
            {
                case 1:
                    AppendPeople(people, step);
                    break;
                case 2:
                    Search(people, step);
                    break;
                default:
                    throw new Exception($"Incorrect value : {choose}");
            }
        }

        public static void AppendPeople(List<Person> people, int step)
        {
            Console.Clear();
            Console.Write("Insert Name: ");
            string name = Console.ReadLine();
            people.Add(new Person(name));
            Menu(people, step);
        }

        public static void Search(List<Person> people, int step)
        {
            Console.Clear();
            int losers = 0;
            int index = -1;
            int round = 0;

            while (losers < people.Count - step + 1)
            {
                round++;
                index = FindNextLoserIndex(people, index, step);
                people[index].ChangeStatus();
                GetInfo(people, round);
                losers = CountLosers(people);
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("THAT'S ALL");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, User!");
            Console.WriteLine("Please insert step");
            Int32.TryParse(Console.ReadLine(), out int step);
            
            List<Person> people = new List<Person>();
            Menu(people, step);  
        }
    }
}
