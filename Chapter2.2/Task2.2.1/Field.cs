using System;

namespace Task2._2._1
{
    public class Field
    {
        private string[,] field = new string[25, 25];

        public Field()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    field[i, j] = ".";
                }
            }
        }

        public void ReloadField()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    field[i, j] = ".";
                }
            }
        }

        public void AddPlayers(params AbstractPlayer[] player)
        {
            foreach (AbstractPlayer ap in player)
            {
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (ap.GetPosition()[0] == j && ap.GetPosition()[1] == i)
                        {
                            field[i, j] = ap.GetIcon();
                        }
                    }
                }
            }
        }


        public void AddEnemy(Enemy enemy)
        {   
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (enemy.GetPosition()[0] == j && enemy.GetPosition()[1] == i)
                    {
                        field[i, j] = enemy.GetIcon();
                    }
                }
                Console.WriteLine();
            }
        }

        public void DrawField()
        {
            for(int i = 24; i > 0; i--)
            {
                for(int j = 0; j < 25; j++)
                {
                    Console.Write(field[i,j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public bool IsEmpty(int[] position)
        {
            if (field[position[1], position[0]].Equals("."))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
