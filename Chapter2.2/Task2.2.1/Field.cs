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

        public void RenderField(params AbstractObject[] objects)
        {
            this.ReloadField();
            foreach (AbstractObject ao in objects)
            {
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    { 
                        if (ao.GetPosition()[0] == j && ao.GetPosition()[1] == i)
                        {
                            field[i, j] = ao.GetIcon();
                        }
                    }
                }
            }
        }

        public void DrawField()
        {
            for(int i = 24; i >= 0; i--)
            {
                for(int j = 0; j < 24; j++)
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

        public bool IsBonus(int[] position)
        {
            if (field[position[1], position[0]].Equals("A"))
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
