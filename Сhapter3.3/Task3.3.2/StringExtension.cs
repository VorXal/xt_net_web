using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3._3._2
{
    public static class StringExtension
    {
        public enum StringType
        {
            None,
            Russian,
            English,
            Number,
            Mixed
        }

        public static StringType GetStringType(this string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                if (StringIsEnglish(inputString))
                {
                    return StringType.English;
                }
                else if (StringIsRussian(inputString))
                {
                    return StringType.Russian;
                }
                else if (StringIsDigit(inputString))
                {
                    return StringType.Number;
                }
                else if (StringIsMixed(inputString))
                {
                    return StringType.Mixed;
                }
                else
                {
                    return StringType.None;
                }
            }
            else
            {
                return StringType.None;
            }
        }

        private static bool StringIsEnglish(string str)
        {
            str = str.ToLower();
            return Regex.IsMatch(str, @"\b([a-z])+\b");
        }

        private static bool StringIsRussian(string str)
        {
            str = str.ToLower();
            return Regex.IsMatch(str, @"\b([а-яё])+\b");
        }

        private static bool StringIsMixed(string str)
        {
            str = str.ToLower();
            return Regex.IsMatch(str, @"([a-zA-Z]|[а-яА-Я]|[0-9])+\w");
        }

        private static bool StringIsDigit(string str)
        {
            str = str.ToLower();
            return Regex.IsMatch(str, @"\b[\d]+\b");
        }
    }
}
