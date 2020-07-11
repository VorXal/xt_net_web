using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] array;
        public int Length { get
            {
                return array.Length;
            }
        }

        public int Capacity {get; private set;}

        public T this[int index]
        {
            get
            {
                if (CheckIndex(index))
                {
                    return array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Trying to GET {index+1} element, when array have {Length} elements");
                }
            }
            set
            {
                if (CheckIndex(index))
                {
                    array[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Trying to SET {index + 1} element, when array have {Length} elements");
                }
            }
        }

        private bool CheckIndex(int index)
        {
            if(index < 0 || index >= Length)
            {
                return false;
            }
            return true;
        }

        private int CalculateCapacity(int count)
        {
            int i = 8;
            while(i < count)
            {
                i *= 2;
            }
            return i;
        }

        public DynamicArray()
        {
            array = new T[8];
            Capacity = CalculateCapacity(8);
        }

        public DynamicArray(int n)
        {   
            array = new T[n];
            Capacity = CalculateCapacity(n);
        }

        public DynamicArray(IEnumerable<T> ts)
        {
            array = new T[ts.Count()];
            for(int i = 0; i < ts.Count(); i++)
            {
                array[i] = ts.ElementAt(i);
            }
            Capacity = CalculateCapacity(ts.Count());
        }

        public void Add(T item)
        {
            if(Length == Capacity)
            {
                Capacity *= 2;
            }
            T[] ts = new T[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                ts[i] = array[i];
            }
            array = ts;
            array[Length - 1] = item;

        }


        public void AddRange(IEnumerable<T> ts)
        {
            if (Length + ts.Count() > Capacity)
            {
                Capacity *= 2;
            }
            T[] ts1 = new T[Length + ts.Count()];
            for(int i = 0; i < Length; i++)
            {
                ts1[i] = array[i];
            }            
            for(int i = 0; i < ts.Count(); i++)
            {
                ts1[Length + i] = ts.ElementAt(i);
            }
            array = ts1;
        }

        public bool RemoveAtIndex(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                return false;
                //I think this should be exception ArgumentOutOfRangeException
            }
            else
            {
                T[] ts = new T[Length - 1];
                for (int i = 0; i < ts.Count(); i++)
                {
                    if (i < index)
                    {
                        ts[i] = array[i];
                    }
                    else
                    {
                        ts[i] = array[i + 1];
                    }
                }
                array = ts;
                return true;
            }
        }

        public bool Insert(T item, int index)
        {
            if (index > Length - 1 || index < 0)
            {
                return false;
                //I think this should be exception ArgumentOutOfRangeException
            }
            else
            {
                T[] ts = new T[Length + 1];
                for (int i = 0; i < ts.Count(); i++)
                {
                    if (i < index)
                    {
                        ts[i] = array[i];
                    }
                    else if (i == index)
                    {
                        ts[i] = item;
                    }
                    else
                    {
                        ts[i] = array[i - 1];
                    }
                }
                array = ts;
                return true;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }
    }
}
