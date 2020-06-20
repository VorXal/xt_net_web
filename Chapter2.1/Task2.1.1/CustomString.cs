using System;

namespace Task2._1._1
{
    public class CustomString
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


        public CustomString(char[] input)
        {
            this.customString = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                customString[i] = input[i];
            }
        }

        public CustomString(string input)
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

            CustomString cs = (CustomString)obj;
            return (this.customString == cs.customString);
        }

        public CustomString ConcatCustomString(CustomString secondCustomString)
        {
            int firstCustomStringLength = customString.Length;
            CustomString firstCustomString = new CustomString(customString);
            customString = new char[customString.Length + secondCustomString.Length];

            for(int i = 0; i < firstCustomStringLength + secondCustomString.Length; i++)
            { 
                if(i < firstCustomStringLength)
                {
                    customString[i] = firstCustomString[i];
                }
                else
                {
                    customString[i] = secondCustomString[i - firstCustomString.Length];
                }
            }

            return new CustomString(customString);
        }

        public static CustomString ConcatCustomString(CustomString firstCustomString, CustomString secondCustomString)
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

            return new CustomString(customString);
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

        public static int GetPositionCharInCustomString(char find, CustomString input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == find)
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

        public static char[] ReturnArray(CustomString input)
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

        public static int CountOfCharInCustomString(char find, CustomString input)
        {
            int count = 0;

            foreach(var i in input.customString)
            {
                if(i == find)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
