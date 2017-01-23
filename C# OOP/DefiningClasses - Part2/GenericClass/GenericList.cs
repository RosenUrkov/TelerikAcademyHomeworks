namespace GenericClass
{
    using System.Collections.Generic;
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private T[] array;
        private int counter;

        public GenericList(int capacity)
        {
            this.array = new T[capacity];
            this.counter = 0;
        }

        public int Count
        {
            get
            {
                return this.counter;
            }
        }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                /* return the specified index here */
                IndexValidation(index);
                return this.array[index];
            }
            set
            {
                /* set the specified index to value here */
                IndexValidation(index);
                this.array[index] = value;
            }
        }

        private void IndexValidation(int index)
        {
            if (index >= this.counter || index<0)
            {
                throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
            }
        }

        private void AutoGrow()
        {
            var temp = new T[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                temp[i] = this.array[i];
            }
            this.array = temp;
        }

        public void Add(T element)
        {
            while (this.counter >= this.array.Length)
            {
                AutoGrow();
            }
            this.array[this.counter] = element;
            this.counter++;
        }

        public void RemoveElementAt(int index)
        {
            IndexValidation(index);
            for (int i = index; i < counter-1; i++)
            {
                array[i] = array[i + 1];
            }
            array[counter] = default(T);
            this.counter--;
        }

        public void InsertElement(int index, T element)
        {
            if (index > this.counter || index < 0)
            {
                throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            while (this.counter >= this.array.Length)
            {
                AutoGrow();
            }

            var temp = new T[this.array.Length];
            int tempIndex = 0;
            for (int i = 0; i < array.Length-1; i++,tempIndex++)
            {
                if(i == index)
                {                   
                    temp[tempIndex] = element;
                    tempIndex++;
                }
                temp[tempIndex] = this.array[i];
            }
            this.array = temp;
            this.counter++;
        }

        public void Clear()
        {
            var temp = new T[this.array.Length];
            this.array = temp;
            this.counter = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.counter; i++)
            {
                if (array[i].CompareTo(element)==0)
                {
                    return i;
                }                
            }
            return -1;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < this.counter; i++)
            {
                builder.Append(array[i] + " ");
            }
            return builder.ToString();
        }

        public T Min()
        {
            T smallestElement = default(T);         
            for (int i = 0; i < counter; i++)
            {
                if (smallestElement.CompareTo(array[i]) > 0)
                {
                    smallestElement = array[i];
                }
            }            
            
            return smallestElement;            
        }

        public T Max()
        {
            var temp = array;
            Array.Sort(temp);
            return temp[temp.Length-1];

        }

    }
}
