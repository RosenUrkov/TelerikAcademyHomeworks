using System;
using System.Collections;
using System.Collections.Generic;

namespace Deque
{
    public class Deque<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] buffer;
        private int size;
        private int capacity;
        private int startIndex;

        public Deque()
        {
            this.buffer = new T[InitialCapacity];
            this.capacity = this.buffer.Length;
            this.size = 0;
            this.startIndex = 0;
        }

        public int Size => this.size;

        public int Capacity => this.capacity;

        private int StartIndex => this.startIndex;

        private int EndIndex => (this.startIndex + this.size) % this.capacity;

        public void PushFront(T element)
        {
            if (this.size >= this.capacity)
            {
                this.Resize();
            }

            this.startIndex = this.size == 0 ? 0 : this.DecrementIndex(this.startIndex);
            this.buffer[this.startIndex] = element;

            this.size++;
        }

        public void PushBack(T element)
        {
            if (this.size >= this.capacity)
            {
                this.Resize();
            }
            
            this.buffer[this.EndIndex] = element;
            this.size++;
        }

        public T PopFront()
        {
            var element = this.buffer[this.startIndex];
            this.buffer[this.startIndex] = default(T);

            this.startIndex = this.IncrementIndex(this.startIndex);
            this.size--;

            return element;
        }

        public T PopBack()
        {
            var endIndex = this.DecrementIndex(this.EndIndex);

            var element = this.buffer[endIndex];
            this.buffer[endIndex] = default(T);

            this.size--;
            return element;
        }

        public T PeekFront()
        {
            return this.buffer[this.startIndex];
        }

        public T PeekBack()
        {
            return this.buffer[this.DecrementIndex(this.EndIndex)];
        }

        public void Clear()
        {
            this.buffer = new T[this.capacity];
            this.startIndex = 0;
            this.size = 0;
        }


        public T this[int index]
        {
            get => this.buffer[this.AdaptIndex(index)];
            set => this.buffer[this.AdaptIndex(index)] = value;
        }

        private void Resize()
        {
            int newCapacity = this.capacity * 2;
            var newBuffer = new T[newCapacity];

            for (int i = 0; i < this.size; i++)
            {
                newBuffer[i] = this[i];
            }

            this.buffer = newBuffer;
            this.capacity = newBuffer.Length;
            this.startIndex = 0;
        }

        private int AdaptIndex(int index)
        {
            var realIndex = this.startIndex + index;
            if (realIndex >= this.capacity)
            {
                realIndex -= this.capacity;
            }

            return realIndex;
        }

        private int IncrementIndex(int index)
        {
            index++;
            if (index >= this.capacity)
            {
                index -= this.capacity;
            }

            return index;
        }

        private int DecrementIndex(int index)
        {
            index--;
            if (index < 0)
            {
                index = this.capacity + index;
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
