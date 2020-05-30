using System;

namespace Task2._1._1
{
    class CustomString
    {
        char[] customString;

        public void PrintCustomString()
        {
            foreach(var i in this.customString)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public static void PrintCustomString(CustomString input)
        {
            foreach (var i in input.customString)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public int GetLength()
        {
            return customString.Length;
        }

        public bool IsEqual(CustomString secondCustomString)
        {
            if(customString.Length == secondCustomString.GetLength())
            {
                for(int i = 0; i < customString.Length; i++)
                {
                    if(customString[i] == secondCustomString.customString[i])
                    {
                        if(i == customString.Length - 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEqual(CustomString firstCustomString, CustomString secondCustomString)
        {
            if (firstCustomString.GetLength() == secondCustomString.GetLength())
            {
                for (int i = 0; i < firstCustomString.GetLength(); i++)
                {
                    if (firstCustomString.customString[i] == secondCustomString.customString[i])
                    {
                        if (i == firstCustomString.GetLength() - 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public CustomString ConcatCustomString(CustomString secondCustomString)
        {
            int firstCustomStringLength = customString.Length;
            CustomString firstCustomString = new CustomString(customString);
            customString = new char[customString.Length + secondCustomString.GetLength()];

            for(int i = 0; i < firstCustomStringLength + secondCustomString.GetLength(); i++)
            { 
                if(i < firstCustomStringLength)
                {
                    customString[i] = firstCustomString.customString[i];
                }
                else
                {
                    customString[i] = secondCustomString.customString[i - firstCustomString.GetLength()];
                }
            }

            return new CustomString(customString);
        }

        public static CustomString ConcatCustomString(CustomString firstCustomString, CustomString secondCustomString)
        {
            char[] customString = new char[firstCustomString.GetLength() + secondCustomString.GetLength()];

            for (int i = 0; i < firstCustomString.GetLength() + secondCustomString.GetLength(); i++)
            {
                if (i < firstCustomString.GetLength())
                {
                    customString[i] = firstCustomString.customString[i];
                }
                else
                {
                    customString[i] = secondCustomString.customString[i - firstCustomString.GetLength()];
                }
            }

            return new CustomString(customString);
        }

        public int FindCharInCustomString(char find)
        {
            for (int i = 0; i < this.GetLength(); i++)
            {
                if (this.customString[i] == find)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindCharInCustomString(char find, CustomString input)
        {
            for(int i = 0; i < input.GetLength(); i++)
            {
                if(input.customString[i] == find)
                {
                    return i;
                }
            }
            return -1;
        }

        public char[] ReturnArray()
        {
            return this.customString;
        }

        public static char[] ReturnArray(CustomString input)
        {
            return input.customString;
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
    }
}
