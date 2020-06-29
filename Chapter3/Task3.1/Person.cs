using System;

namespace Task3._1
{
    class Person
    {
        public string Name { get; private set; }
        public bool Winner { get; private set; } = true;

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string status = Winner ? "Winner" : "Loser";
            return $"Name: {Name}, Status: {status} ";
        }
        public void ChangeStatus()
        {
            Winner = false;
        }

    }
}
