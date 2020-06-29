using System;

namespace Task3._1
{
    class Program
    {
        public static void GetInfo(Person[] people, int round)
        {
            Console.WriteLine($"Round: {round}");
            foreach(Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static int GetNextLoserId(Person[] people, int step)
        {
            int indexNow = 1;
            while (true)
            {
                if (indexNow >= people.Length)
                {
                    indexNow -= people.Length;
                }
                if (people[indexNow + step].Winner)
                    return indexNow + step;
                else
                {
                    indexNow += step;
                }
            }
        }
        static void Main(string[] args)
        {
            int step = 3;
            Person person = new Person("Alexey");
            Person person1 = new Person("Sergey");
            Person person2 = new Person("Ivan");
            Person person3 = new Person("Alexandr");
            Person person4 = new Person("Mila");
            Person person5 = new Person("Elena");
            Person[] people = new Person[] { person, person1, person2, person3, person4, person5};


            foreach(Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            int losers = 0;
            

            while(losers < people.Length - 1)
            {
                people[GetNextLoserId(people, step)].ChangeStatus();
                losers++;
                GetInfo(people, losers);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
