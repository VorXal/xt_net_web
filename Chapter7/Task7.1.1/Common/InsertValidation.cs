using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class InsertValidation
    {
        public static int InsertIntRange(int min, int max)
        {
            int result;
            bool flag = false;
            Console.Write("Your select: ");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag || result < min || result > max)
                {
                    Console.WriteLine("Incorrect insert\n");
                    Console.WriteLine("Try one more time");
                    flag = false;
                }

            } while (!flag);
            Console.WriteLine();
            return result;
        }
        
    }
}
