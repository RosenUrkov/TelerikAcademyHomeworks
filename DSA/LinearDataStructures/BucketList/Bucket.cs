using System;
using System.Collections;
using System.Collections.Generic;

namespace BucketList
{
    public class Bucket<T> : IEnumerable<T>
    {
        private T[] elements;
        private int size;
        private int capacity;

        public Bucket(int capacity)
        {
            this.elements = new T[capacity];
            this.capacity = capacity;

            this.size = 0;
            this.StartIndex = 0;
        }

        public int Size => this.size;

        public int Capacity => this.capacity;

        public bool IsFull => this.capacity == this.size;

        public int StartIndex { get; set; }

        public int EndIndex => (this.StartIndex + this.size) % this.capacity;

        public T this[int index]
        {
            get => this.elements[(this.StartIndex + index) % this.capacity];
            set => this.elements[(this.StartIndex + index) % this.capacity] = value;
        }

        public void Add(T element)
        {
            this[this.size] = element;
            size++;
        }

        public void Insert(int index, T value)
        {

            size++;
        }

        public void Remove(int index)
        {

            size--;
        }

        public void Clear() => this.elements = new T[this.capacity];

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
