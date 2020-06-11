using System;

namespace Task2._1._1
{
    public class CustomStringFromDLL
    {
        private char[] customString;
        public int Length
        {
            get
            {
                return customString.Length;
            }
        }

        public char this[int index]
        {
            get
            {
                return customString[index];
            }
            private set
            {
                customString[index] = value;
            }
        }


        public CustomStringFromDLL(char[] input)
        {
            this.customString = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                customString[i] = input[i];
            }
        }

        public CustomStringFromDLL(string input)
        {
            this.customString = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                customString[i] = input[i];
            }
        }

        public override string ToString()
        {
            return new string(this.customString);
        }

        public override int GetHashCode()
        {
            return this.customString.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            CustomStringFromDLL cs = (CustomStringFromDLL)obj;
            return (this.customString == cs.customString);
        }

        public CustomStringFromDLL ConcatCustomString(CustomStringFromDLL secondCustomString)
        {
            int firstCustomStringLength = customString.Length;
            CustomStringFromDLL firstCustomString = new CustomStringFromDLL(customString);
            customString = new char[customString.Length + secondCustomString.Length];

            for (int i = 0; i < firstCustomStringLength + secondCustomString.Length; i++)
            {
                if (i < firstCustomStringLength)
                {
                    customString[i] = firstCustomString[i];
                }
                else
                {
                    customString[i] = secondCustomString[i - firstCustomString.Length];
                }
            }

            return new CustomStringFromDLL(customString);
        }

        public static CustomStringFromDLL ConcatCustomString(CustomStringFromDLL firstCustomString, CustomStringFromDLL secondCustomString)
        {
            char[] customString = new char[firstCustomString.Length + secondCustomString.Length];

            for (int i = 0; i < firstCustomString.Length + secondCustomString.Length; i++)
            {
                if (i < firstCustomString.Length)
                {
                    customString[i] = firstCustomString[i];
                }
                else
                {
                    customString[i] = secondCustomString[i - firstCustomString.Length];
                }
            }

            return new CustomStringFromDLL(customString);
        }

        public int GetPositionCharInCustomString(char find)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == find)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int GetPositionCharInCustomString(char find, CustomStringFromDLL input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == find)
                {
                    return i;
                }
            }
            return -1;
        }

        public char[] ReturnArray()
        {
            return (char[])this.customString.Clone();
        }

        public static char[] ReturnArray(CustomStringFromDLL input)
        {
            return (char[])input.customString.Clone();
        }

        public int CountOfCharInCustomString(char find)
        {
            int count = 0;

            foreach (var i in this.customString)
            {
                if (i == find)
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountOfCharInCustomString(char find, CustomStringFromDLL input)
        {
            int count = 0;

            foreach (var i in input.customString)
            {
                if (i == find)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
