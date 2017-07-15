using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IEnumerable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compare;
        
        public PriorityQueue(Func<T, T, bool> compareFunc)
        {
            this.heap = new List<T>();
            this.heap.Add(default(T)); // indeces start from 1
            this.compare = compareFunc;
        }

        public T Peek => this.heap[1];

        public int Count => this.heap.Count - 1;

        public bool IsEmpty => this.Count == 0;

        public void Enqueue(T element)
        {
            this.heap.Add(element);
            int index = this.Count;

            this.HeapifyUp(index, element);
        }

        public T Dequeue()
        {
            var topElement = this.Peek;

            var lowestElement = this.heap[this.Count];
            this.heap.RemoveAt(this.Count);

            this.HeapifyDown(1, lowestElement);
            return topElement;
        }

        public bool Contains(T element)
        {
            return this.heap.Contains(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.heap.Skip(1).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void HeapifyUp(int index, T value)
        {
            while (index > 1 && this.compare(value, this.heap[index / 2]))
            {
                this.heap[index] = this.heap[index / 2];
                index /= 2;
            }

            this.heap[index] = value;
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < this.heap.Count)
            {
                int childIndex = this.compare(heap[index * 2], heap[index * 2 + 1]) ?
                                    index * 2 :
                                    index * 2 + 1;

                if (this.compare(value, this.heap[childIndex]))
                {
                    break;
                }

                this.heap[index] = this.heap[childIndex];
                index = childIndex;
            }

            if (index * 2 < this.heap.Count)
            {
                int childIndex = index * 2;
                if (this.compare(this.heap[childIndex], value))
                {
                    this.heap[index] = this.heap[childIndex];
                    index = childIndex;
                }
            }

            this.heap[index] = value;
        }
    }
}
