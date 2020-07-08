using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Task3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Please insert path for your text: ");
            string path = Console.ReadLine();
            path = $@"{path}";
            if (File.Exists(path))
            {
                stringBuilder.Append(File.ReadAllText(path));
            }
            else
            {
                throw new Exception("Can't find file");
            }
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            string str = stringBuilder.ToString().ToLower();
            char[] chars = { ' ', ',', ':', '.', '!', '?'};
            string[] words = str.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in words)
            {
                if(pairs.ContainsKey(item))
                {
                    pairs[item]++;
                }
                else
                {
                    pairs.Add(item, 1);
                }
            }
            foreach (KeyValuePair<string, int> kvp in pairs)
            {
                Console.WriteLine("Word = \"{0}\", Count = {1}",
                    kvp.Key, kvp.Value);
            }
            Console.ReadKey();
        }
    }
}
