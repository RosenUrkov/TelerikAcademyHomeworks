using LinkedList;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList.LinkedList<T> list;

        public Queue()
        {
            this.list = new LinkedList.LinkedList<T>();
        }

        public int Size => this.list.Size;

        public void Clear() => this.list.Clear();

        public T Peek() => this.list.First.Value;

        public void Enqueue(T element)
        {
            this.list.Add(element);
        }

        public T Dequeue()
        {
            var element = this.Peek();
            this.list.Remove(this.list.First);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var element = this.list.First;
            while(element != null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
