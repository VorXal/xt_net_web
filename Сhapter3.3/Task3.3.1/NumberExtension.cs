using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._1
{
    public static class NumberExtension
    {
        public static double Sum(this double[] array)
        {
            double sum = 0;
            foreach (double item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static int Sum(this int[] array)
        {
            int sum = 0;
            foreach(int item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static double Average(this double[] array) => array.Sum() / array.Length;

        public static double Average(this int[] array) => array.Sum() / (double)array.Length;

        public static double MaxRepeat(this double[] array)
        {
            Dictionary<double, int> repeats = new Dictionary<double, int>();
            foreach(double item in array)
            {
                if (repeats.ContainsKey(item))
                {
                    repeats[item]++;
                }
                else
                {
                    repeats.Add(item, 1);
                }
            }
            return repeats.OrderBy(i => i.Value).LastOrDefault().Key;

        }

        public static int MaxRepeat(this int[] array)
        {
            Dictionary<int, int> repeats = new Dictionary<int, int>();
            foreach (int item in array)
            {
                if (repeats.ContainsKey(item))
                {
                    repeats[item]++;
                }
                else
                {
                    repeats.Add(item, 1);
                }
            }
            return repeats.OrderBy(i => i.Value).LastOrDefault().Key;
        }

    }
}
