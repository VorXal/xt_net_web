using System;

namespace Task2._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(12, 24, 100);
            Enemy enemy = new Enemy(12, 17, 20);
            Apple apple = new Apple(1, 1, 20);
            Field main = new Field();
            Block block = new Block(4, 17);
            Block block1 = new Block(4, 16);
            main.RenderField(player, enemy, apple, block, block1);
            main.DrawField();
            int i = 0;
            while (true)
            {
                i++;
                player.ChangePosition(Console.ReadKey().Key, main);
                Console.Clear();
                main.RenderField(player, enemy, apple, block, block1);
                if(i % 2 == 1)
                {
                    enemy.Attack(player, main);
                }

                apple.SetEffect(player);

                main.DrawField();
                Console.WriteLine(player.GetInfo());

                if(player.Health <= 0)
                {
                    break;
                }
            }
            Console.WriteLine("Game Over!!!");
            Console.ReadKey();
        }
    }
}
