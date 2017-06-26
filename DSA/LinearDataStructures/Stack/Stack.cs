using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] buffer;
        private int size;
        private int capacity;

        public Stack()
        {
            this.buffer = new T[InitialCapacity];
            this.capacity = buffer.Length;
            this.size = 0;
        }

        public int Size => this.size;

        public int Capacity => this.capacity;

        public void Clear() => this.buffer = new T[this.capacity];

        public T Peek() => this.buffer[this.size - 1];

        public void Push(T element)
        {
            if(this.Size >= this.Capacity)
            {
                this.Resize(this.capacity * 2);
            }

            this.buffer[this.size] = element;
            this.size++;
        }

        public T Pop()
        {
            var element = this.buffer[this.size - 1];
            this.buffer[this.size - 1] = default(T);

            this.size--;
            return element;
        }

        public void Shrink()
        {
            this.Resize(this.size);
        }
        
        private void Resize(int newCapacity)
        {
            this.capacity = newCapacity;
            var newBuffer = new T[this.capacity];

            for (int i = 0; i < this.size; i++)
            {
                newBuffer[i] = this.buffer[i];
            }

            this.buffer = newBuffer;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
